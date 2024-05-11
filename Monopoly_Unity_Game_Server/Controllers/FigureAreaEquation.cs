using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("FigureAreaEquation/")]
    public class FigureAreaEquation : Controller
    {
        public FigureAreaEquation(CalculationArea_1 calculationArea_1) 
        {
            _calculationArea_1 = calculationArea_1;
        }


        private CalculationArea_1 _calculationArea_1;


        [HttpGet]
        [Route("calculationArea_1")]
        public GameSquareExample GenerateQuadraticEquationWithA1Question()
        {
            Question question = _calculationArea_1.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }
    }
}


