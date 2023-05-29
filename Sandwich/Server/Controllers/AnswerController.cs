using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.ModelBinding;

namespace Sandwich.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [HttpGet]
        public IEnumerable<Opzione> Get()
        {
            return db.GetAnswer();
        }

        [HttpPost]
        public void Post([FromBody] Opzione obj)
        {
            if (ModelState.IsValid == true)
            {
                db.AddAnswer(obj);
            }
            else { }
        }

        [HttpGet(nameof(GetByAnswer))]
        public IEnumerable<Opzione> GetByAnswer(int id)
        {
            var result = db.GetAnswer().Where(model => model.ProgDomanda == id);
            return result;
        }

    }
}
