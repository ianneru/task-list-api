using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Infrastructure.Data;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.Infrastructure.Repositories.Repositories;

namespace TaskList.Infrastructure.Repositories.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public const string DatabaseProvider = "DatabaseProvider";

        public const string DatabaseConnectionString = "DatabaseConnectionString";

        public const string DatabaseName = "DatabaseName";

        public static IDictionary<string, Func<IConfiguration, DbContextOptionsBuilder, DbContextOptionsBuilder>>
            DatabaseProviderLookup =
                new Dictionary<string, Func<IConfiguration, DbContextOptionsBuilder, DbContextOptionsBuilder>>
                {
                    {"", UseInMemoryDatabaseProvider},
                    {"InMemory", UseInMemoryDatabaseProvider},
                    {"SqlServer", UseSqlServerDatabaseProvider}
                };

        public static IServiceCollection AddDatabaseProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = configuration[DatabaseProvider];
            
            services.AddDbContext<AppDbContext>(opt => DatabaseProviderLookup[provider](configuration, opt));
            
            services.AddScoped<AppDbContext>();

            services.AddTransient<Seeder>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            
            services.AddScoped<IUsarioRepository, UsuarioRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static DbContextOptionsBuilder UseInMemoryDatabaseProvider(IConfiguration configuration,
            DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            return dbContextOptionsBuilder.UseInMemoryDatabase(configuration[DatabaseName]);
        }

        private static DbContextOptionsBuilder UseSqlServerDatabaseProvider(IConfiguration configuration,
            DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            return dbContextOptionsBuilder.UseSqlServer(configuration[DatabaseConnectionString]);
        }
    }
}