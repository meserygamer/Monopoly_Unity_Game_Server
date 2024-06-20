using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("DegreeQuestion/")]
    public class DegreeQuestionController : Controller
    {
        public DegreeQuestionController(DegreeWithNaturalExponentFactory degreeWithNaturalExponentFactory,
                                        PropertiesOfDegreesFactory propertiesOfDegreesFactory,
                                        PropertiesOfDegreesWith0andNegativeFactory propertiesOfDegreesWith0AndNegativeFactory) 
        {
            _degreeWithNaturalExponentFactory = degreeWithNaturalExponentFactory;
            _propertiesOfDegreesFactory = propertiesOfDegreesFactory;
            _propertiesOfDegreesWith0AndNegativeFactory = propertiesOfDegreesWith0AndNegativeFactory;
        }


        private DegreeWithNaturalExponentFactory _degreeWithNaturalExponentFactory;
        private PropertiesOfDegreesFactory _propertiesOfDegreesFactory;
        private PropertiesOfDegreesWith0andNegativeFactory _propertiesOfDegreesWith0AndNegativeFactory;


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
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("CalculateDegreeWith0andNegativeExponentPropertiesFactory")]
        public GameSquareExample CalculateDegreeWith0andNegativeExponentProperties()
        {
            Question question = _propertiesOfDegreesWith0AndNegativeFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }
    }
}
