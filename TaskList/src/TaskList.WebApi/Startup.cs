using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TaskList.Application.WebApi.Extensions;
using TaskList.Infrastructure.Authentication.Extensions;
using TaskList.Infrastructure.Repositories;
using TaskList.Infrastructure.Repositories.Extensions;
using TaskList.Services.Extensions;

namespace TaskList.Web
{
    public class Startup
    {

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                  .AddCors()
                  .AddMapper()
                  .AddDatabaseProvider(Configuration)
                  .AddAuthenticationProvider(Configuration)
                  .AddRepositories()
                  .AddServices()
                  .AddSwagger()
                  //.AddSwaggerGen()
                  .AddControllers()
                  .AddNewtonsoftJson(options =>
                      options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  );
            ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task List V1"); });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            //Db migrado para o azure
            //seeder.SeedSimpleUser().GetAwaiter().GetResult();
        }


    }
}
