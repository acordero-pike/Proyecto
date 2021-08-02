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
    public class ComentarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(int IdCurso)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var comentario = (from d in db.Comentarios.Where(b=>b.IdCurso==IdCurso)
                                select d).ToList();

                return Ok(comentario);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.ComentarioSolicitud modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Comentario com = new Models.Comentario();
                com.Pregunta = modelo.Pregunta;
                com.Leccion = modelo.Leccion;
                com.Respuesta = "Sin Respuesta";
                com.IdCurso = modelo.IdCurso;

                db.Comentarios.Add(com);
                db.SaveChanges();


            }
            return Ok("Se agrego correctamente");
        }


        [HttpPut]
        public ActionResult Put([FromBody] Models.Comentario modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Comentario com = db.Comentarios.Find(modelo.IdComentario);
                Console.WriteLine(modelo.IdComentario);
                com.Pregunta = modelo.Pregunta;
                com.Leccion = modelo.Leccion;
                com.Respuesta = modelo.Respuesta;

                db.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();


            }
            return Ok("Comentario actualizado correctamente");
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Comentario modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Comentario comentario = db.Comentarios.Find(modelo.IdComentario);
                db.Comentarios.Remove(comentario);
                db.SaveChanges();

            }
            return Ok("Comentario eliminado correctamente");
        }

    }
}

