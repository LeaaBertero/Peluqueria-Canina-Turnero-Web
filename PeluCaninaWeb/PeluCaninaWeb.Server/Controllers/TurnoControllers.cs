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
    [Route("api/Turno")]

    public class TurnoControllers : ControllerBase
    {
        private readonly ITurnoRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        public TurnoControllers(ITurnoRepositorio repositorio, 
                                IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> Get(int id)
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
        public async Task<ActionResult<int>> Post(CrearTurnoDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.Email = entidadDTO.Email;
                //entidad.Contraseña = entidadDTO.Contraseña;
                //entidad.Teléfono = entidadDTO.Teléfono;
                //entidad.Dirección = entidadDTO.Dirección;
                //entidad.Cuit_Cuil = entidadDTO.Cuit_Cuil;
                //entidad.Fecha_Registro = entidadDTO.Fecha_Registro;

                Turno entidad = mapper.Map<Turno>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] Turno entidad)
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

            dammy.FechaHora = entidad.FechaHora;
            dammy.Nota = entidad.Nota;
            
           



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
                return NotFound($"El turno {id} no existe.");
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
