using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    //Albin
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost]

        public ActionResult Post([FromBody] Models.Compra modelo)
        {
             
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {

                 
                Models.Compra compra = new Models.Compra();
 
                

                 
                compra.IdEstudiante = modelo.IdEstudiante;
                compra.Fecha = System.DateTime.Now;
                compra.Total = modelo.Total;



                db.Compras.Add(compra);
                db.SaveChanges();
              var  x = from a in db.Compras select a.IdCompra;
                return Ok(x.Max());
            }
           
            
        }

    }
}
