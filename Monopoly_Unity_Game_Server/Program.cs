
using Microsoft.OpenApi.Models;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;

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
            builder.Services.AddSingleton<CalculationArea_2>();
            builder.Services.AddSingleton<CalculationArea_3>();
            builder.Services.AddSingleton<DegreeWithNaturalExponentFactory>();
            builder.Services.AddSingleton<PropertiesOfDegreesFactory>();
            builder.Services.AddSingleton<PropertiesOfDegreesWith0andNegativeFactory>();
            builder.Services.AddSingleton<CalculateRoot2And3Factory>();
            builder.Services.AddSingleton<PropertiesOfRootFactory>();
            builder.Services.AddSingleton<OrdinaryFractionsWithSameDenominatorsFactory>();
            builder.Services.AddSingleton<OrdinaryFractionsWithDifferentDenominatorsFactory>();

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
