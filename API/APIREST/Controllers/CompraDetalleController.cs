using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompraDetalleController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Models.Detalle modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {

                Models.Detalle detalle = new Models.Detalle();
                 

                detalle.CodCurso = modelo.CodCurso;
                detalle.Precio = modelo.Precio;
                detalle.IdCompra = modelo.IdCompra;
                
                


                db.Detalles.Add(detalle);
                db.SaveChanges();

            }
            return Ok("se añadió correctamente");
        }
    }
}
