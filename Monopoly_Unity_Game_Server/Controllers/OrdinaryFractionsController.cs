using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.OrdinaryFractions;
using Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Controller]
    [Route("OrdinaryFractions/")]
    public class OrdinaryFractionsController : Controller
    {
        public OrdinaryFractionsController(OrdinaryFractionsWithSameDenominatorsFactory ordinaryFractionsWithSameDenominatorsFactory, OrdinaryFractionsWithDifferentDenominatorsFactory ordinaryFractionsWithDiffentDenominatorsFactory)
        {
            _ordinaryFractionsWithSameDenominatorsFactory = ordinaryFractionsWithSameDenominatorsFactory;
            _ordinaryFractionsWithDiffentDenominatorsFactory = ordinaryFractionsWithDiffentDenominatorsFactory;
        }


        private OrdinaryFractionsWithSameDenominatorsFactory _ordinaryFractionsWithSameDenominatorsFactory;
        private OrdinaryFractionsWithDifferentDenominatorsFactory _ordinaryFractionsWithDiffentDenominatorsFactory;


        [HttpGet]
        [Route("CalculateOrdinaryFractionsWithSameDenominators")]
        public GameSquareExample CalculateOrdinaryFractionsWithSameDenominators() 
        {
            Question question = _ordinaryFractionsWithSameDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

        [HttpGet]
        [Route("CalculateOrdinaryFractionsWithDifferentDenominators")]
        public GameSquareExample CalculateOrdinaryFractionsWithDifferentDenominators()
        {
            Question question = _ordinaryFractionsWithDiffentDenominatorsFactory.GetQuestion();
            return new GameSquareExample() { Question = question, DefaultTimeForAnswerInSecond = 20 };
        }

    }
}
