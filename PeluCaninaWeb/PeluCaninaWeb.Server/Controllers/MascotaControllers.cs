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
    [Route("api/Mascota")]

    public class MascotaControllers : ControllerBase
    {
        private readonly IMascotaRepositorio repositorio;
        private readonly IMapper mapper;

        public MascotaControllers(IMascotaRepositorio repositorio, 
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mascota>> Get(int id)
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
        public async Task<ActionResult<int>> Post(CrearMascotaDTO entidadDTO)
        {
            try
            {


                Mascota entidad = mapper.Map<Mascota>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] Mascota entidad)
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
            dammy.Edad = entidad.Edad;
            dammy.Peso = entidad.Peso;
            dammy.Descripcion = entidad.Descripcion;
            dammy.Especie = entidad.Especie;
            dammy.Raza = entidad.Raza;
            




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
                return NotFound($"La mascota {id} no existe.");
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
