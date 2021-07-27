using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class detalleController : Controller
    {

        [HttpGet("{id}")]


        public ActionResult dtl(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var datos = db.Detalles.Where(g => g.IdCompra == id).Select(g => new { Nombre = g.IdCompraNavigation.IdEstudianteNavigation.IdUsuarioNavigation.Nombre + " " + g.IdCompraNavigation.IdEstudianteNavigation.IdUsuarioNavigation.Apellido, Nit = g.IdCompraNavigation.IdEstudianteNavigation.Nit, Fecha = g.IdCompraNavigation.Fecha, Curso = g.CodCursoNavigation.Nombre, Precio = g.CodCursoNavigation.Costo * 1.20 }).ToList();

                return Ok(datos);
            }
        }
    }
}
