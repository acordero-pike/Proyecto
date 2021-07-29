using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
//albin cordero 13/07/2021
namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {



        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var usuario = (from d in db.Usuarios
                                select d).ToList();
                return Ok(usuario);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetUsuario(int id)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                var usuario = db.Usuarios.Find(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
        }

        [HttpGet("{Correo},{Contraseña}")]
        public ActionResult validar(string Correo, string Contraseña)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                

                var query = db.Usuarios.Where(a => a.Correo==Correo && a.Contraseña == Contraseña).Select(g => new { ID = g.IdUsuario, Nombre = g.Nombre + ' '+g.Apellido }).ToList();
             
                if (query.Count()<1)
                {
                    var query1 = new { status = "400" };
                    // creamos un listado de peticion
                    return Ok(query1);
                }

                return Ok(query);
            }
        }

         //lOURDES 

        [HttpPost]
        public ActionResult Post([FromBody] Models.Usuario modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                Models.Usuario usuario = new Models.Usuario();
                usuario.Nombre = modelo.Nombre;
                usuario.Apellido = modelo.Apellido;
                usuario.Telefono = modelo.Telefono;
                usuario.Correo = modelo.Correo;
                usuario.Contraseña = modelo.Contraseña;
                usuario.Status = true;

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                return Ok(usuario.IdUsuario);

            }
          
        }



        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Usuario modelo)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
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
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
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
