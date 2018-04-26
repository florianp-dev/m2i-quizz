using Services;
using System.Web.Http;

namespace FilRouge.API.Controllers
{
    [Authorize]
    public class PercentsController : ApiController
    {
        private PercentService _service = new PercentService();

        [HttpGet]
        public IHttpActionResult Index(int? id = null)
        {
            if (id == null)
                return Ok(_service.GetAllPercents());

            return Ok(_service.GetPercentById((int)id));
        }
    }
}