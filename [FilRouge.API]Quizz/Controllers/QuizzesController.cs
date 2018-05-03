using Services;
using System.Web.Http;

namespace FilRouge.API.Controllers
{
    public class QuizzesController : ApiController
    {
        private static readonly QuizzService _service = new QuizzService();

        [HttpGet]
        public IHttpActionResult Get(int? id = null)
        {
            if (id == null)
                return Ok(_service.GetAllQuizzes());
            return Ok(_service.GetQuizById((int)id));
        }
    }
}