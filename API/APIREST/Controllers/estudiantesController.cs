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
        public ActionResult Post([FromQueryAttribute] Models.Usuario modelo, Models.Estudiante modeloEstudiante)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Estudiante estudiante = new Models.Estudiante();
                Models.Usuario usuario = new Usuario();
                usuario.Status = true;
                db.Usuarios.Add(usuario);
                db.SaveChanges();


                estudiante.IdUsuario = usuario.IdUsuario;
                estudiante.Nit = modeloEstudiante.Nit;
                estudiante.NumTarjeta = modeloEstudiante.NumTarjeta;
                usuario.Nombre = modeloEstudiante.IdUsuarioNavigation.Nombre;
                usuario.Apellido = modeloEstudiante.IdUsuarioNavigation.Apellido;
                usuario.Telefono = modeloEstudiante.IdUsuarioNavigation.Telefono;
                usuario.Correo = modeloEstudiante.IdUsuarioNavigation.Correo;
                usuario.Contraseña = modeloEstudiante.IdUsuarioNavigation.Contraseña;

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
                Models.Estudiante estudiante = db.Estudiantes.Find(modelo.IdEstudianes);
                estudiante.Nit = modelo.Nit;
                estudiante.NumTarjeta = modelo.NumTarjeta;

                db.Entry(estudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("estudiante actualizado correctamente");
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var query = db.Estudiantes.Select(estudiante => new
                {
                    IdUsuario = estudiante.IdUsuarioNavigation.IdUsuario,
                    IdEstudiante = estudiante.IdEstudianes,
                    Nombre = estudiante.IdUsuarioNavigation.Nombre,
                    Apellido = estudiante.IdUsuarioNavigation.Apellido,
                    Telefono = estudiante.IdUsuarioNavigation.Telefono,
                    Correo = estudiante.IdUsuarioNavigation.Correo,
                    Contraseña = estudiante.IdUsuarioNavigation.Contraseña,
                    Nit = estudiante.Nit,
                    NumeroTarjeta = estudiante.NumTarjeta
                }).Where(estudiante => estudiante.IdEstudiante == id).ToList();

                return Ok(query);
               
            }
        }
    }
}
