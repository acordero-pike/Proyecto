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
    public class instructoresController : ControllerBase
    {
        //lourdes 21/07/2021
        [HttpPost]
        public ActionResult Post([FromBody] Models.DatosInstructor modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.DatosInstructor instructor = new Models.DatosInstructor();

                instructor.Estudios = modelo.Estudios;
                instructor.Certificacion = modelo.Certificacion;
                instructor.ExperienciaLab = modelo.ExperienciaLab;
                instructor.CuentaBancaria = modelo.CuentaBancaria;
                instructor.Usuario = modelo.Usuario;

                db.DatosInstructors.Add(instructor);
                db.SaveChanges();
            }
            return Ok("instructor añadido correctamente");
        }

        //lourdes 22/07/2021
        [HttpPut]
        public ActionResult Put([FromBody] Models.DatosInstructor modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.DatosInstructor instructor = db.DatosInstructors.Find(modelo.IdInstructor);
                instructor.Estudios = modelo.Estudios;
                instructor.Certificacion = modelo.Certificacion;
                instructor.ExperienciaLab = modelo.ExperienciaLab;
                instructor.CuentaBancaria = modelo.CuentaBancaria;

                db.Entry(instructor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("estudiante actualizado correctamente");
        }
    }
}
