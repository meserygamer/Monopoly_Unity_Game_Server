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
        public DecimalController( DecimalSimpleExampleOfAddOrSubFactory decimalSimpleExampleOfAddOrSubFactory,
                                  DecimalSimpleExampleOfMulOrDivFactory decimalSimpleExampleOfMulOrDivFactory )
        {
            _decimalSimpleExampleOfAddOrSubFactory = decimalSimpleExampleOfAddOrSubFactory;
            _decimalSimpleExampleOfMulOrDivFactory = decimalSimpleExampleOfMulOrDivFactory;
        }


        private DecimalSimpleExampleOfAddOrSubFactory _decimalSimpleExampleOfAddOrSubFactory;
        private DecimalSimpleExampleOfMulOrDivFactory _decimalSimpleExampleOfMulOrDivFactory;


        [HttpGet]
        [Route("CalculateDecimalSimpleExampleOfAddOrSub")]
        public GameSquareExample CalculateDecimalSimpleExampleOfAddOrSub() 
        {
            Question question = _decimalSimpleExampleOfAddOrSubFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("CalculateDecimalSimpleExampleOfMulOrDiv")]
        public GameSquareExample CalculateDecimalSimpleExampleOfMulOrDiv()
        {
            Question question = _decimalSimpleExampleOfMulOrDivFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

    }
}
