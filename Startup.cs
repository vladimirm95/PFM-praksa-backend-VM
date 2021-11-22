using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Npgsql;
using Transactions.Database;

namespace Transactions 
{
    public class Startup 
    {
       public Startup (IConfiguration configuration)             
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

               //this method gets called by runtime. Use this method to add services to container

        public void ConfigureServices (IServiceCollection services) {

            services.AddControllers();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Transactions", Version ="v1"});

            });

            services.AddDbContext<TransactionsDbContext>(options => {
                options.UseNpgsql(CreateConnectionString());

            });

        }
                 //configure http request pipeline
        public void Configure (IApplicationBuilder app,IWebHostEnvironment env){

            if ( env.IsDevelopment()){
                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transactions v1"));

            }
            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
         private string CreateConnectionString()
        {
            var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? this.Configuration["Database:Username"];
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? this.Configuration["Database:Password"];
            var host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? this.Configuration["Database:Host"];
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? this.Configuration["Database:Port"];
            var database = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? this.Configuration["Database:Name"];

            var builder = new NpgsqlConnectionStringBuilder()
            {
                Username = username,
                Password = password,
                Host = host,
                Port = int.Parse(port),
                Database = database,
                Pooling = true
            };

            return builder.ConnectionString;
        }
     }
    }
