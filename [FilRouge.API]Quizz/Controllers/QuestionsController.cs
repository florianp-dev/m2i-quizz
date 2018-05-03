using Services;
using System.Web.Http;
using ModelEntities.ModelViews;

namespace FilRouge.API.Controllers
{
    public class QuestionsController : ApiController
    {
        private static readonly QuestionService _service = new QuestionService();

        // GET: api/Questions/?id
        [HttpGet]
        public IHttpActionResult Get(int? id = null)
        {
            if (id == null)
            {
                var qApi = _service.GetAllQuestionsApi();
                return Ok(qApi);
            }
                
            return Ok(_service.GetById((int) id).MapToQuestionsApiViewModel());
        }

        // DELETE: api/Questions/5
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
