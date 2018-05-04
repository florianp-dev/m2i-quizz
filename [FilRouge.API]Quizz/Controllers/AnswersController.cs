using System.Web.Http;
using Services;

namespace FilRouge.API.Controllers
{
    public class AnswersController : ApiController
    {
        private static readonly AnswersService _service = new AnswersService();

        // GET: /api/Answers/8
        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            // TODO A TESTER
            return Ok(_service.GetAnswerByQuestionId(id));
        }
    }
}
