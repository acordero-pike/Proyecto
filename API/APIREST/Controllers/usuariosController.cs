using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            using(Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                var usuario = (from d in db.Usuarios select d).ToList();
                return Ok(usuario);
            }
        }
    }
}
