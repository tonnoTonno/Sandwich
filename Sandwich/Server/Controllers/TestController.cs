using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.ModelBinding;

namespace Sandwich.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return db.GetTest();
        }

        [HttpPost]
        public void Post([FromBody] Test obj)
        {
            if (ModelState.IsValid == true)
            {
                db.AddTest(obj);
            }
            else { }
        }

        [HttpGet(nameof(GetById))]
        public IEnumerable<Test> GetById(int id)
        {
            var result = db.GetTest().Where(model => model.IdTest == id);
            return result;
        }

    }
}
