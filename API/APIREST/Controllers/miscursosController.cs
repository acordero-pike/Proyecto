using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Controllers
{//albin
    [Route("api/[controller]/")]
    [ApiController]
    public class miscursosController : Controller
    {
        [HttpGet("{id}")]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult miscursos(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var datos = db.Detalles.Where(g => g.IdCompraNavigation.IdEstudiante == id).Select(g => new { IdCurso=g.CodCurso,Nombre = g.CodCursoNavigation.Nombre, Descripcion = g.CodCursoNavigation.Descripcion, IdInstructor=g.CodCursoNavigation.IdInstructorNavigation.UsuarioNavigation.Nombre , Lecciones = g.CodCursoNavigation.Leccions.Count(),Duracion=g.CodCursoNavigation.Duracion}).ToList();

                return Ok(datos);
            }
        }
    }
}
