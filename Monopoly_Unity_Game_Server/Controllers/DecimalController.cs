using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DecimalExamples;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("Decimal/")]
    public class DecimalController : Controller
    {
        public DecimalController( DecimalSimpleExampleOfAddOrSubFactory decimalSimpleExampleOfAddOrSubFactory,
                                  DecimalSimpleExampleOfMulOrDivFactory decimalSimpleExampleOfMulOrDivFactory,
                                  DecimalSimpleExampleWithTwoActionsFactory decimalSimpleExampleWithTwoActionsFactory )
        {
            _decimalSimpleExampleOfAddOrSubFactory = decimalSimpleExampleOfAddOrSubFactory;
            _decimalSimpleExampleOfMulOrDivFactory = decimalSimpleExampleOfMulOrDivFactory;
            _decimalSimpleExampleWithTwoActionsFactory = decimalSimpleExampleWithTwoActionsFactory;
        }


        private DecimalSimpleExampleOfAddOrSubFactory _decimalSimpleExampleOfAddOrSubFactory;
        private DecimalSimpleExampleOfMulOrDivFactory _decimalSimpleExampleOfMulOrDivFactory;
        private DecimalSimpleExampleWithTwoActionsFactory _decimalSimpleExampleWithTwoActionsFactory;


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

        [HttpGet]
        [Route("DecimalSimpleExampleWithTwoActions")]
        public GameSquareExample DecimalSimpleExampleWithTwoActions()
        {
            Question question = _decimalSimpleExampleWithTwoActionsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

    }
}
