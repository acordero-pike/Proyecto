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
    public class usuariosActvivosController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Models.Usuario modelo)
        {
            using (Models.proyectoCursosContext db = new Models.proyectoCursosContext())
            {
                Models.Usuario usuario = db.Usuarios.Find(modelo.IdUsuario);
                usuario.Status = true;

                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Usuario activo");
        }
    }
}
