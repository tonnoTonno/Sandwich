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

        [HttpGet]
        public IEnumerable<Utente> Get()
        {
            return db.GetUtenti();
        }

        [HttpPost]
        public void Post([FromBody] Utente obj)
        {
            if (ModelState.IsValid == true)
            {
                db.AddUtente(obj);
            }
            else{}
        }

        [HttpGet(nameof(GetByMail))]
        public IEnumerable<Utente> GetByMail(string Mail)
        {
                var result = db.GetUtenti().Where(model => model.Mail == Mail);
                return result;
        }

    }
}
