using Microsoft.AspNetCore.Mvc;
using Sandwich.Shared;
using System.Web.Http.OData;

namespace Sandwich.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        ContextDb db = new ContextDb();

        [EnableQuery]
        [HttpGet]
        public IEnumerable<Utente> Get()
        {
            return db.GetUtente();
        }

        [EnableQuery]
        [HttpPost]
        public void Post([FromBody] Utente obj)
        {
            if (ModelState.IsValid == true)
            {
                db.Add(obj);
            }
            else{}
        }

    }
}
