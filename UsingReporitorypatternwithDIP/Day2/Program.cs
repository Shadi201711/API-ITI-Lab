
using Day2.Models;
using Day2.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ITI API",
                    Version = "v1",
                    Description = "ITI API Description",
                    TermsOfService = new System.Uri("https://www.google.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "shadii",
                        Email = "shadi@gmail.com"
                    }

                });
                o.IncludeXmlComments("C:\\Users\\shadi\\Desktop\\Day3Lab\\GenericRepository\\Day2\\XMLfile");
                o.EnableAnnotations();
            });


            builder.Services.AddDbContext<ITIContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("ITICon")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                 builder =>
                 {
                     builder.AllowAnyOrigin();
                     builder.AllowAnyMethod();
                     builder.AllowAnyHeader();
                 });
            });
            builder.Services.AddScoped<StudentRepository>();
            builder.Services.AddScoped<DepartmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}
