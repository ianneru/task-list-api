using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TaskList.Application.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            static bool IsExpandableType(PropertyMap map)
            {
                var propertyType = TryGetMemberType(map.SourceMember) ?? TryGetMemberType(map.DestinationMember);
                return IsExpandableClass(propertyType) || IsExpandableEnumerable(propertyType);
            }

            static bool IsExpandableClass(Type propertyType)
            {
                return propertyType != null && propertyType != typeof(string) && propertyType.IsClass;
            }

            static bool IsExpandableEnumerable(Type propertyType)
            {
                return propertyType != null && propertyType != typeof(string) && propertyType.IsGenericType &&
                       typeof(ICollection<>).IsAssignableFrom(
                           propertyType
                               .GetGenericTypeDefinition());
            }

            static Type TryGetMemberType(MemberInfo member)
            {
                return (member as PropertyInfo)?.PropertyType ?? (member as FieldInfo)?.FieldType;
            }

            services.AddAutoMapper(configuration =>
            {
                configuration.AddExpressionMapping();
                configuration.ForAllPropertyMaps(IsExpandableType, (m, o) => o.ExplicitExpansion());
            }, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}