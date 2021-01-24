using Microsoft.Extensions.DependencyInjection;
using TaskList.Services.Interfaces;
using TaskList.Services.Services;
using TaskList.Domain.Entities;
using TaskList.Infrastructure.CrossCutting.Validators.Interfaces;
using TaskList.Services.Validators;

namespace TaskList.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITarefaService, TarefaService>();
            
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddValidators();

            return services;
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceValidator<>), typeof(ServiceValidator<>));
            
            services.AddTransient<ISaveValidator<Tarefa>, TarefaValidator>();
            
            services.AddTransient<IUpdateValidator<Tarefa>, TarefaValidator>();
        }
    }
}