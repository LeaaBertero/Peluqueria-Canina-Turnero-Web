using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]

    public class UsuarioControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public UsuarioControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuario.ToListAsync();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? pepe = await context.Usuario
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pepe == null)
            {
                return NotFound($"El usuario {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario entidad)
        {

            try
            {
                context.Usuario.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }



        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await context.Usuario.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Reserva no encontrada");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Apellido = entidad.Apellido;
            dammy.Email = entidad.Email;
            dammy.Contrasenia = entidad.Contrasenia;
            dammy.Telefono = entidad.Telefono;
            dammy.Rol = entidad.Rol;

            try
            {
                context.Usuario.Update(dammy);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }

        }
        #endregion

        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuario.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El usuario {id}, no existe");
            }

            Usuario entidadBorrar = new Usuario();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);

            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion

    }
}
