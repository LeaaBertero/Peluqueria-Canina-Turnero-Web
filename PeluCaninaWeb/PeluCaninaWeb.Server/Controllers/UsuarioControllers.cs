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
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;
        #endregion

        #region constructor
        public UsuarioControllers(IUsuarioRepositorio repositorio, 
                                  IMapper mapper)
        {

            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var dammy = await repositorio.SelectById(id);

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
               

                Usuario entidad = mapper.Map<Usuario>(entidadDTO);

                return await repositorio.Insert(entidad);

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

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Apellido = entidad.Apellido;
            dammy.Email = entidad.Email;
            dammy.Contrasenia = entidad.Contrasenia;
            dammy.Telefono = entidad.Telefono;
            dammy.Rol = entidad.Rol;
           



            try
            {
                await repositorio.Update(id, dammy);


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
            var existe = repositorio.Existe(id);

            if (!await existe) //await existe
            {
                return NotFound($"El usuario {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

    }
}





