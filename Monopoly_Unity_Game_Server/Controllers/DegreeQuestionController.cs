using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("DegreeQuestion/")]
    public class DegreeQuestionController : Controller
    {
        public DegreeQuestionController(DegreeWithNaturalExponentFactory degreeWithNaturalExponentFactory, PropertiesOfDegreesFactory propertiesOfDegreesFactory) 
        {
            _degreeWithNaturalExponentFactory = degreeWithNaturalExponentFactory;
            _propertiesOfDegreesFactory = propertiesOfDegreesFactory;
        }


        private DegreeWithNaturalExponentFactory _degreeWithNaturalExponentFactory;
        private PropertiesOfDegreesFactory _propertiesOfDegreesFactory;


        [HttpGet]
        [Route("CalculateDegreeWithNaturalExponent")]
        public GameSquareExample CalculateDegreeWithNaturalExponent()
        {
            Question question = _degreeWithNaturalExponentFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 15 };
        }

        [HttpGet]
        [Route("CalculateDegreeProperties")]
        public GameSquareExample CalculateDegreeProperties()
        {
            Question question = _propertiesOfDegreesFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 15 };
        }
    }
}
