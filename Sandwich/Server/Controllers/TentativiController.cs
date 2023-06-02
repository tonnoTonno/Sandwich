using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.ModelBinding;

namespace Sandwich.Server.Controllers
{
    public class TentativiController
    {
        [Route("/api/Tentativi")]
        [ApiController]
        public class TentativoController : ControllerBase
        {
            ContextDb db = new ContextDb();

            [HttpGet]
            public IEnumerable<Tentativo> Get()
            {
                return db.GetTry();
            }

            //[HttpPost]
            //public void Post([FromBody] Tentativo obj)
            //{
            //    if (ModelState.IsValid == true)
            //    {
            //        db.AddTry(obj);
            //    }
            //    else { }
            //}

            //[HttpGet(nameof(GetByTest))]
            //public IEnumerable<Tentativo> GetByTest(int id)
            //{
            //    var result = db.GetQuestion().Where(model => model. == id);
            //    return result;
            //}

        }
    }
}
