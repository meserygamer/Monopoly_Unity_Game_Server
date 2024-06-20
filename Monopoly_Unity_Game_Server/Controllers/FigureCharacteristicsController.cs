using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.FigureCharacteristics;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("RootQuestion/")]
    public class FigureCharacteristicsController : Controller
    {
        public FigureCharacteristicsController(TriangleSquareRectangleCharacteristicsFactory triangleSquareRectangleCharacteristicsFactory,
            TrapezoidRhombusParallelogramCharacteristicsFactory trapezoidRhombusParallelogramCharacteristicsFactory)
        {
            _triangleSquareRectangleCharacteristicsFactory = triangleSquareRectangleCharacteristicsFactory;
            _trapezoidRhombusParallelogramCharacteristicsFactory = trapezoidRhombusParallelogramCharacteristicsFactory;
        }


        private TriangleSquareRectangleCharacteristicsFactory _triangleSquareRectangleCharacteristicsFactory;
        private TrapezoidRhombusParallelogramCharacteristicsFactory _trapezoidRhombusParallelogramCharacteristicsFactory;


        [HttpGet]
        [Route("CalculateTriangleSquareRectangleCharacteristics")]
        public GameSquareExample CalculateTriangleSquareRectangleCharacteristics() 
        {
            Question question = _triangleSquareRectangleCharacteristicsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 25 };
        }

        [HttpGet]
        [Route("CalculateTrapezoidRhombusParallelogramCharacteristics")]
        public GameSquareExample CalculateTrapezoidRhombusParallelogramCharacteristics()
        {
            Question question = _trapezoidRhombusParallelogramCharacteristicsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 30 };
        }

    }
}
