using FluentMigrator.Runner;
using Grpc.Services.Configurations;
using Grpc.Services.FluentMigrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Grpc.Services
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region bind config

            services.Configure<AppConnections>(this.Configuration.GetSection("ConnectionStrings"));
            var connectionCfg = new AppConnections();
            this.Configuration.Bind("ConnectionStrings", connectionCfg);
            services.AddSingleton<AppConnections>(connectionCfg);

            #endregion bind config

            services.AddGrpc();
            services.AddGrpcSwagger();

            services.AddGrpc();

            //FluentMiration DB
            services.AddFluentMigratorCore()
               .ConfigureRunner(builder => builder
               .AddSqlServer()
               .WithGlobalConnectionString(connectionCfg.DefaultConnection)
               .ScanIn(typeof(AddTable_User).Assembly).For.Migrations());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
            });

            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            // Run the migrations
            runner.MigrateUp();
        }
    }
}