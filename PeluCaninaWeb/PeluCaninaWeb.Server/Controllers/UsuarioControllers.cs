using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Server.Repositorio;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]

    public class UsuarioControllers : ControllerBase
    {
        #region Campos privados
        private readonly Context context;
        private readonly IMapper mapper;
        #endregion

        #region constructor
        public UsuarioControllers(Context context, 
                                  IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuario.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var dammy = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                //Mascota entidad = new Mascota();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Edad = entidadDTO.Edad;
                //entidad.Peso = entidadDTO.Peso;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.Especie = entidadDTO.Especie;
                //entidad.Raza = entidadDTO.Raza;

                Usuario entidad = mapper.Map<Usuario>(entidadDTO);

                context.Usuario.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
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

            var dammy = await context.Usuario.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Usuario no encontrado");
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
            catch (Exception e)
            {

                return BadRequest(e.Message);
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
                return NotFound($"La mascota {id} no existe.");
            }

            Usuario EntidadAborrar = new Usuario();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El usuario {id} fue eliminada correctamente.");
        }
        #endregion



    }
}





