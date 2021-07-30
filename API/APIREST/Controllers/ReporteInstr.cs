using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    //Albin
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteInstr : Controller
    {
        [HttpGet]


        public ActionResult instructor(int id)
        {

            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
               // var datos = db.Detalles
                return Ok();
            }
        }

    }
}
