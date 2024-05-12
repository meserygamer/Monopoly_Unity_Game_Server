using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("Decimal/")]
    public class DecimalController : Controller
    {
        public DecimalController( DecimalSimpleExampleOfAddOrSubFactory decimalSimpleExampleOfAddOrSubFactory )
        {
            _decimalSimpleExampleOfAddOrSubFactory = decimalSimpleExampleOfAddOrSubFactory;
        }


        private DecimalSimpleExampleOfAddOrSubFactory _decimalSimpleExampleOfAddOrSubFactory;


        [HttpGet]
        [Route("CalculateDecimalSimpleExampleOfAddOrSub")]
        public GameSquareExample CalculateDecimalSimpleExampleOfAddOrSub() 
        {
            Question question = _decimalSimpleExampleOfAddOrSubFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

    }
}
