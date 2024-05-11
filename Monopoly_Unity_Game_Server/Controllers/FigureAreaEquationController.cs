using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("FigureAreaEquation/")]
    public class FigureAreaEquationController : Controller
    {
        public FigureAreaEquationController(CalculationArea_1 calculationArea_1, CalculationArea_2 calculationArea_2, CalculationArea_3 calculationArea_3) 
        {
            _calculationArea_1 = calculationArea_1;
            _calculationArea_2 = calculationArea_2;
            _calculationArea_3 = calculationArea_3;
        }


        private CalculationArea_1 _calculationArea_1;
        private CalculationArea_2 _calculationArea_2;
        private CalculationArea_3 _calculationArea_3;


        [HttpGet]
        [Route("calculationArea_1")]
        public GameSquareExample GenerateArea_1Question()
        {
            Question question = _calculationArea_1.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

        [HttpGet]
        [Route("calculationArea_2")]
        public GameSquareExample GenerateArea_2Question()
        {
            Question question = _calculationArea_2.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }

        [HttpGet]
        [Route("calculationArea_3")]
        public GameSquareExample GenerateArea_3Question()
        {
            Question question = _calculationArea_3.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }
    }
}


