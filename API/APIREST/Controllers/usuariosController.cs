using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

//albin cordero 13/07/2021
namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UsuariosController(
          
           IConfiguration configuration)
        {
         
            this._configuration = configuration;
        }


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
        public async Task<IActionResult> validar(string Correo, string Contraseña)
        {
            using (Models.ProyectocrsContext db = new Models.ProyectocrsContext())
            {
                int id = 0;
                string rol = null;

                var query = db.Usuarios.Where(a => a.Correo == Correo && a.Contraseña == Contraseña).Select(g => g.IdUsuario);

                if (query.Count() < 1)
                {
                    var query1 = new { status = "400" };
                    // creamos un listado de peticion
                    return Ok(query1);
                }
                else
                {
                    var x = from a in db.Estudiantes where a.IdUsuario == query.First() select a.IdEstudianes;
                    var y = from a in db.DatosInstructors where a.Usuario == query.First() select a.IdInstructor;

                    if (x.Count()>0)
                    {
                        rol = "Estudiante";
                        id = x.First();
                    }
                    else if(y.Count() > 0) {
                        rol = "Instructor";
                        id = y.First();
                    }

                   else if(x.Count() <1 && y.Count()<1)
                    {
                        rol = "Administrador";
                        id = query.First();
                    }


                }
               
                return BuildToken(Correo, Contraseña,rol,id);


            }
        }
        [HttpGet("{token}")]
        public ActionResult desce(string token)
        {
            var tk = new JwtSecurityTokenHandler().ReadToken(token);

            return Ok(tk);
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
            }
            return Ok("usuario añadido correctamente");
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

        private IActionResult BuildToken(string Correo, string Contraseña ,string rol,int id)
        {
            Models.ProyectocrsContext db = new Models.ProyectocrsContext();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, Correo),
                new Claim("Rol", rol),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            string llave = "Llave_super_secreta";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(llave));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            var query = db.Usuarios.Where(a => a.Correo == Correo && a.Contraseña == Contraseña).Select(g => new { ID = id, Nombre = g.Nombre + ' ' + g.Apellido, token = new JwtSecurityTokenHandler().WriteToken(token) }).ToList();

            return Ok(query);

        }
    }

}
