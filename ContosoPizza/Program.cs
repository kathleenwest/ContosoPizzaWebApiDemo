using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ContosoPizza
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
          
            // In order to use JsonPatch, you need to Add NewtonsoftJson support to your controllers here!
            builder.Services.AddControllers().AddNewtonsoftJson();

            // Swagger/OpenAPI 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Simple Pizza Api", 
                    Description = "A simple ASP.NET Core Web Api application with CRUD including Patch that allows you to work with pizza data",
                    Contact = new OpenApiContact
                    {
                        Name = "Kathleen West",
                        Email = "hello.kathleen.west@gmail.com",
                        Url = new Uri("https://portfolio.katiegirl.net")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                    Version = "v1"
                });

                // generate the xml docs that will swagger will utilize
                string xmlFilePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilePath);
                c.IncludeXmlComments(xmlPath);

                // Add Descriptive Api Names for Client References 
                c.CustomOperationIds(apiDescription =>
                {
                    return apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                });

            })
                .AddSwaggerGenNewtonsoftSupport(); // Add support for JsonPatch here

            // Create the web application
            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.

            // Change configurations based on environmental settings
            // HINT: See Project Properties --> Debug --> Launch Profiles --> Select
            // Add ASPNETCORE_ENVIRONMENT = "Development"
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Pizza Api v1");
                    
                    // Displays the Operational Name of the Api endpoints
                    c.DisplayOperationId();
                });
            }
            else
            {
                // By-Pass the Developer Exception Page, Use Concise Version
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Let's get this party started!
            app.Run();
        }
    }
}