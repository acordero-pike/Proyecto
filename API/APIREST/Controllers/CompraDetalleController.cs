using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    //Debora 
    [Route("api/[controller]")]
    [ApiController]

    public class CompraDetalleController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Models.Detalle modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {

                Models.Detalle detalle = new Models.Detalle();
                Models.Compra compra = new Models.Compra();

                db.Compras.Add(compra);
                db.SaveChanges();

                detalle.CodCurso = modelo.CodCurso;
                detalle.Precio = modelo.Precio;
                detalle.IdCompra = compra.IdCompra;
                compra.IdEstudiante = modelo.IdCompraNavigation.IdEstudiante;
                compra.Fecha = modelo.IdCompraNavigation.Fecha;
                compra.Total = modelo.IdCompraNavigation.Total;



                db.Detalles.Add(detalle);
                db.SaveChanges();

            }
            return Ok("se añadió correctamente");
        }
    }
}
