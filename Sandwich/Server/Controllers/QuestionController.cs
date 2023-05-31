using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.ModelBinding;

namespace Sandwich.Server.Controllers
{
    [Route("/api/Question")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [HttpGet]
        public IEnumerable<Domanda> Get()
        {
            return db.GetQuestion();
        }

        [HttpPost]
        public void Post([FromBody] Domanda obj)
        {
            if (ModelState.IsValid == true)
            {
                db.AddQuestion(obj);
            }
            else { }
        }

        [HttpGet(nameof(GetByTest))]
        public IEnumerable<Domanda> GetByTest(int id)
        {
            var result = db.GetQuestion().Where(model => model.IdTest == id);
            return result;
        }

    }
    
}
