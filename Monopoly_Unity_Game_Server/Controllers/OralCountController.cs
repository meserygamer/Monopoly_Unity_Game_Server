using Microsoft.AspNetCore.Mvc;
using Monopoly_Unity_Game_Server.Model;

namespace Monopoly_Unity_Game_Server.Controllers
{
    [Route("OralCount/")]
    public class OralCountController : Controller
    {
        [HttpGet]
        [Route("ExampleWithSingleAction")]
        public GameSquareExample GenerateExampleWithSingleAction()
        {
            
            return new GameSquareExample();
        }
    }
}
