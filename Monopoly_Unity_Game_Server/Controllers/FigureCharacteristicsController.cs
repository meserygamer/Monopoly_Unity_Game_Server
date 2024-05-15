using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.FigureCharacteristics;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("RootQuestion/")]
    public class FigureCharacteristicsController : Controller
    {
        public FigureCharacteristicsController(TriangleSquareRectangleCharacteristicsFactory triangleSquareRectangleCharacteristicsFactory)
        {
            _triangleSquareRectangleCharacteristicsFactory = triangleSquareRectangleCharacteristicsFactory;
        }


        private TriangleSquareRectangleCharacteristicsFactory _triangleSquareRectangleCharacteristicsFactory;


        [HttpGet]
        [Route("CalculateTriangleSquareRectangleCharacteristics")]
        public GameSquareExample CalculateTriangleSquareRectangleCharacteristics() 
        {
            Question question = _triangleSquareRectangleCharacteristicsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

    }
}
