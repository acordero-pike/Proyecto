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
                var cursos = (from d in db.Cursos
                              select d).ToList();
                return Ok(cursos);
            }

        }

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
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Curso modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                bool validar;
                var query = (from r in db.Cursos where r.IdCurso == modelo.IdCurso select r).Count();

                if(query==0)
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
                    return Ok("Est Curso ya tiene participantes, no se puede eliminar");
                }
               
            }
            
        }
    }
}
