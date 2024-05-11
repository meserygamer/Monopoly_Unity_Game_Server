using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("RootQuestion/")]
    public class RootQuestionController : Controller
    {
        public RootQuestionController(CalculateRoot2And3Factory calculateRoot2And3Factory)
        {
            _calculateRoot2And3Factory = calculateRoot2And3Factory;
        }


        private CalculateRoot2And3Factory _calculateRoot2And3Factory;


        [HttpGet]
        [Route("CalculateRoot2And3")]
        public GameSquareExample CalculateRoot2And3() 
        {
            Question question = _calculateRoot2And3Factory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 10 };
        }
    }
}
