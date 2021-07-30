using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class CursosController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                
                var query = db.Cursos.Select(g => new { IdCurso=g.IdCurso, Nombre=g.Nombre, Descripcion=g.Descripcion, Costo = g.Costo*1.20 , IdInstructor = g.IdInstructorNavigation.UsuarioNavigation.Nombre, Duracion = g.Duracion ,Cantidad=g.Detalles.Count()}).ToList(); //solo los nombres del producto con el rpecio para activar una funcion del front

                 
                return Ok(query);
            }

        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {

 
                var query = db.Cursos.Where(g=> g.IdInstructor==id).Select(g => new { IdCurso = g.IdCurso, Nombre = g.Nombre, Descripcion = g.Descripcion, Costo = g.Costo * 1.20, IdInstructor = g.IdInstructorNavigation.UsuarioNavigation.Nombre, Duracion = g.Duracion, Cantidad = g.Detalles.Count() , Gan = g.Detalles.Where(h => h.CodCurso==g.IdCurso).Sum(h =>h.CodCursoNavigation.Costo) }).ToList(); //solo los nombres del producto con el rpecio para activar una funcion del front

                
                return Ok(query);
            }

        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.CursoSolicitud modelo 
            )
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Curso cursos = new Models.Curso();
                cursos.Nombre = modelo.Nombre;
                cursos.Descripcion = modelo.Descripcion;
                cursos.Costo = modelo.Costo;
                cursos.IdInstructor = (int)modelo.IdInstructor;
                cursos.Duracion = modelo.Duracion;

                db.Cursos.Add(cursos);
                db.SaveChanges();

            }
            return Ok("El curso se añadió correctamente");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPut]
        public ActionResult Put([FromBody] Models.Curso modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Curso cursos = db.Cursos.Find(modelo.IdCurso);
                cursos.Nombre = modelo.Nombre;
                cursos.Descripcion = modelo.Descripcion;
                cursos.Costo = modelo.Costo;
                cursos.IdInstructor = modelo.IdInstructor;
                cursos.Duracion = modelo.Duracion;

                db.Entry(cursos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("El curso se Actualizó correctamente");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Curso modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                bool validar;
                var x = from r in db.Cursos where r.IdCurso == modelo.IdCurso select r.Detalles.Count();
                var y = from r in db.Cursos where r.IdCurso == modelo.IdCurso select r.Leccions.Count();
                int query = x.First();
                if(query>0 || y.First()>0)
                {
                    validar = false;
                }
                else
                {
                    validar = true;
                }

                if(validar==true)
                {
                     Models.Curso cursos = db.Cursos.Find(modelo.IdCurso);
                     db.Cursos.Remove(cursos);
                     db.SaveChanges();
                    return Ok("El curso se Eliminó correctamente");

                }
                else
                {
                    var query1 =  new { mess = "Este Curso ya tiene participantes, no se puede eliminar" } ;
                    return BadRequest(query1);
                }
               
            }
            
        }
    }
}
