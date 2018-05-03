using Services;
using System.Web.Http;

namespace FilRouge.API.Controllers
{
    public class QuestionsController : ApiController
    {
        private static readonly QuestionService _service = new QuestionService();

        // GET: api/Questions/?id
        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return Ok(_service.GetAllQuestions());
            return Ok(_service.GetById((int) id));
        }

        // DELETE: api/Questions/5
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
