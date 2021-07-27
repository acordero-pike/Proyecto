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
                var usuario = db.Estudiantes.Select(g => new { IdEstudianes = g.IdEstudianes, Nombre = g.IdUsuarioNavigation.Nombre, Apellido = g.IdUsuarioNavigation.Apellido, Telefono = g.IdUsuarioNavigation.Telefono, Correo = g.IdUsuarioNavigation.Correo, Status = g.IdUsuarioNavigation.Status }).Where(g => g.Status == true).ToList();
                return Ok(usuario);
            }
        }

        [HttpGet("{id}")]
        public ActionResult traercuros(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                try
                {
                    var fac = from a in db.Compras where a.IdEstudiante == id select a.IdCompra;
                    //var leccion = db.Detalles.Where(g => g.IdCompra == fac.First()).Select(g => g.CodCurso);
                    int fc = fac.First();
                    var cursos = db.Detalles.Where(g => g.IdCompra == fac.First()).Select(g => new { Nombre = g.CodCursoNavigation.Nombre, Duracion = g.CodCursoNavigation.Duracion, Instructo = g.CodCursoNavigation.IdInstructorNavigation.UsuarioNavigation.Nombre }).ToList();

                    return Ok(cursos);
                }
                catch
                {
                    return BadRequest();
                }

            }
        }

        
    }

}
