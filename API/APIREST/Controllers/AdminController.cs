using Microsoft.AspNetCore.Authorization;
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
    public class AdminController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult GetEstudiantes()
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var usuario = db.Estudiantes.Select(g=> new { Nombre=g.IdUsuarioNavigation.Nombre , Apellido= g.IdUsuarioNavigation.Apellido , Telefono= g.IdUsuarioNavigation.Telefono, Correo = g.IdUsuarioNavigation.Correo, Status=g.IdUsuarioNavigation.Status } ).Where(g=> g.Status==true).ToList();
                return Ok(usuario);
            }
        }
    }
}
