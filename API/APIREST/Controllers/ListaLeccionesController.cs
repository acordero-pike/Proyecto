using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaLeccionesController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var leccion = (from d in db.Leccions
                               where d.IdLeccion == id
                               select d).ToList();

                return Ok(leccion);
            }

        }
    }
}
