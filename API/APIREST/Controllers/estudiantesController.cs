using APIREST.Models;
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
    public class estudiantesController : ControllerBase
    {
        //lourdes 21/07/2021
        [HttpPost]
        public ActionResult Post([FromBody] Models.Estudiante modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Estudiante estudiante = new Models.Estudiante();
                estudiante.Nit = modelo.Nit;
                estudiante.NumeroTarjeta = modelo.NumeroTarjeta;
                estudiante.Usuario = modelo.Usuario;

                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
            }
            return Ok("estuadiante añadido correctamente");
        }

        //lourdes 22/07/2021
        [HttpPut]
        public ActionResult Put([FromBody] Models.Estudiante modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Estudiante estudiante = db.Estudiantes.Find(modelo.IdEstudiante);
                estudiante.Nit = modelo.Nit;
                estudiante.NumeroTarjeta = modelo.NumeroTarjeta;

                db.Entry(estudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("estudiante actualizado correctamente");
        }

        [HttpGet("{id}")]
        public ActionResult GetEstudiante(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var query = db.Estudiantes.Select(estudiante => new
                {
                    IdUsuario = estudiante.UsuarioNavigation.IdUsuario,
                    IdEstudiante = estudiante.IdEstudiante,
                    Nombre = estudiante.UsuarioNavigation.Nombre,
                    Apellido = estudiante.UsuarioNavigation.Apellido,
                    Telefono = estudiante.UsuarioNavigation.Telefono,
                    Correo = estudiante.UsuarioNavigation.Correo,
                    Contraseña = estudiante.UsuarioNavigation.Contraseña,
                    Nit = estudiante.Nit,
                    NumeroTarjeta = estudiante.NumeroTarjeta
                }).Where(estudiante => estudiante.IdUsuario == id).ToList();

                return Ok(query);
               
            }
        }
    }
}
