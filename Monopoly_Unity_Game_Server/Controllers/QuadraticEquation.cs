using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("QuadraticEquation/")]
    public class QuadraticEquationController : Controller
    {
        public QuadraticEquationController(QuadraticEquationWithA1QuestionFactory quadraticEquationWithA1QuestionFactory) 
        {
            _quadraticEquationWithA1QuestionFactory = quadraticEquationWithA1QuestionFactory;
        }


        private QuadraticEquationWithA1QuestionFactory _quadraticEquationWithA1QuestionFactory;


        [HttpGet]
        [Route("QuadraticEquationWithA1QuestionFactory")]
        public GameSquareExample GenerateExampleWithSingleAction()
        {
            Question question = _quadraticEquationWithA1QuestionFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }
    }
}


