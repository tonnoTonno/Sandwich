using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.ModelBinding;

namespace Sandwich.Server.Controllers
{
    [Route("/api/Test")]
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

        [HttpGet(nameof(GetByCreator))]
        public IEnumerable<Test> GetByCreator(string c)
        {
            var result = db.GetTest().Where(model => model.creatore == c);
            return result;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Test obj)
        {
            if (ModelState.IsValid == true)
            {
                db.EditTest(id, obj);
            }
        }

    }
}
