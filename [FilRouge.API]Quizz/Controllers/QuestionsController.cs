using ModelEntities.ModelViews;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilRouge.API.Controllers
{
    public class QuestionsController : ApiController
    {
        private static readonly QuestionService _service = new QuestionService();

        // GET: api/Questions
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAllQuestions());
        }

        // GET: api/Questions/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetQuestionById(id));
        }

        // POST: api/Questions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Questions/5
        public void Delete(int id)
        {
        }
    }
}
