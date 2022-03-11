using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Services;
using Aplication_Programming_InterfaceJAlmeida.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Aplication_Programming_InterfaceJAlmeida
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(InterfaceMapping));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            

            // Register the Swagger generator, defining 1 or more Swagger documents
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Banca-Clientes API",
                    Description = "API para el manejo de Metodos Entidad Bancaria.",
                    TermsOfService = new Uri("https://www.pichincha.com/portal/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Soporte Banca",
                        Email = string.Empty,
                        Url = new Uri("https://www.pichincha.com/portal/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia propietaria de Banco Pichincha",
                        Url = new Uri("https://www.pichincha.com/portal/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.**
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
            builder.Services.AddDbContext<BancaDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("bancaDb"));
                options.EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
            );

            builder.Services.AddTransient<IPersonasService, PersonasService>();
            builder.Services.AddTransient<ICuentasService, CuentaService>();
            builder.Services.AddTransient<IMovimientosService, MovimientosService>();
        }

        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
