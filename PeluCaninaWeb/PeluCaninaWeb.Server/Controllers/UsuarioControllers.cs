using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
        private readonly IUsuarioRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;


        #region constructor
        public UsuarioControllers(IUsuarioRepositorio repositorio, 
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
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

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound($"El usuario {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
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


            //expresión lambda para buscar el id
            var dammy = await repositorio.SelectById(id);

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
                await repositorio.Update(id, dammy);

                
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
            var existe = await repositorio.Existe(id);
            
            if (!existe == null)
            {
                return NotFound($"El Usuario {id} no encontrado");
            }
            if (await repositorio.Borrar(id))
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
