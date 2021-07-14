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
    public class usuariosController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            using(Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                var usuario = (from d in db.Usuarios select d).ToList();
                return Ok(usuario);
            }


        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Usuario modelo)
        {
            using (Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                Models.Usuario usuario = new Models.Usuario();
                usuario.Nombre = modelo.Nombre;
                usuario.Apellido = modelo.Apellido;
                usuario.Telefono = modelo.Telefono;
                usuario.Correo = modelo.Correo;
                usuario.Contraseña = modelo.Contraseña;

                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
            return Ok("usuario añadido correctamente");
        }

 

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Usuario modelo)
        {
            using (Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                Models.Usuario usuario = db.Usuarios.Find(modelo.IdUsuario);
                usuario.Status = false;

                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("La cuenta del usuario ha sido desactivada satisfactoriamente");
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Usuario modelo)
        {
            using (Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                Models.Usuario usuario = db.Usuarios.Find(modelo.IdUsuario);
                usuario.Nombre = modelo.Nombre;
                usuario.Apellido = modelo.Apellido;
                usuario.Telefono = modelo.Telefono;
                usuario.Correo = modelo.Correo;
                usuario.Contraseña = modelo.Contraseña;

                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            }
            return Ok("usuario actualizado correctamente");
        }
    }
}
