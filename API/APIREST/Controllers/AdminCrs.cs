using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCrs : Controller
    {


        [HttpGet("{crs}")]
        

        public ActionResult getalumnosenroll(int crs)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var datos = db.Detalles.Where(g => g.CodCurso == crs).Select(g => new { Nombre = g.IdCompraNavigation.IdEstudianteNavigation.IdUsuarioNavigation.Nombre, Apellido = g.IdCompraNavigation.IdEstudianteNavigation.IdUsuarioNavigation.Apellido, Correo = g.IdCompraNavigation.IdEstudianteNavigation.IdUsuarioNavigation.Correo }).ToList();


                return Ok(datos);
            }
        }


    }
}
