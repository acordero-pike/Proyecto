using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class compraController : Controller
    {

        [HttpGet("{id}")]
       
        public ActionResult crmp(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {

                var datos = db.Compras.Where(g => g.IdEstudiante == id).Select(g => new { IdCompra=g.IdCompra, Fecha= g.Fecha , Total=g.Total ,Cantidad=g.Detalles.Count() } ).ToList();
                return Ok(datos);
            }
        }



    }
}
