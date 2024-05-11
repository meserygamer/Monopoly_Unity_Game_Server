using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("DegreeQuestion/")]
    public class DegreeQuestionController : Controller
    {
        public DegreeQuestionController(DegreeWithNaturalExponentFactory degreeWithNaturalExponentFactory) 
        {
            _degreeWithNaturalExponentFactory = degreeWithNaturalExponentFactory;
        }


        private DegreeWithNaturalExponentFactory _degreeWithNaturalExponentFactory;


        [HttpGet]
        [Route("CalculateDegreeWithNaturalExponent")]
        public GameSquareExample CalculateDegreeWithNaturalExponent()
        {
            Question question = _degreeWithNaturalExponentFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 15 };
        }
    }
}
