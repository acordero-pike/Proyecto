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
    public class LeccionController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var leccion = (from d in db.Leccions
                                select d).ToList();

                return Ok(leccion);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Solicitudes.LeccionSolicitud modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Leccion lec = new Models.Leccion();
                lec.Titulo = modelo.Titulo;
                lec.Descripcion = modelo.Descripcion;
                lec.Duracion = modelo.Duracion;
                lec.EnlaceVideo = modelo.EnlaceVideo;
                lec.IdCurso = modelo.IdCurso;

                db.Leccions.Add(lec);
                db.SaveChanges();


            }
            return Ok("Se agregado correctamente");
        }


        [HttpPut]
        public ActionResult Put([FromBody] Models.Leccion modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Leccion lec = db.Leccions.Find(modelo.IdLeccion);
                lec.Titulo = modelo.Titulo;
                lec.Descripcion = modelo.Descripcion;
                lec.Duracion = modelo.Duracion;
                lec.Descripcion = modelo.EnlaceVideo;
                lec.IdCurso = modelo.IdCurso;

                db.Entry(lec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();


            }
            return Ok("Leccion actualizada correctamente");
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Leccion modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Leccion empresa = db.Leccions.Find(modelo.IdLeccion);
                db.Leccions.Remove(empresa);
                db.SaveChanges();

            }
            return Ok("Empresa eliminada correctamente");
        }

    }
}

