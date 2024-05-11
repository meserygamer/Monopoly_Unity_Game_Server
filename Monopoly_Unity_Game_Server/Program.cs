
using Microsoft.OpenApi.Models;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;

namespace Monopoly_Unity_Game_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<Random>();
            builder.Services.AddSingleton<SingleActionQuestionFactory>();
            builder.Services.AddSingleton<DoubleActionQuestionFactory>();
            builder.Services.AddSingleton<QuadraticEquationWithA1QuestionFactory>();
            builder.Services.AddSingleton<QuadraticEquationWithB0_C0Factory>();
            builder.Services.AddSingleton<CalculationArea_1>();

            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Monopoly Game Server",
                    Description = ""
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder.AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}
