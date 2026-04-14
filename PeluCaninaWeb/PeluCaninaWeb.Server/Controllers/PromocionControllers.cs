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
    [Route("api/Promocion")]

    public class PromocionControllers : ControllerBase
    {
        private readonly IPromocionRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        public PromocionControllers(IPromocionRepositorio repositorio, 
                                    IMapper mapper)
        {
            this.repositorio = repositorio;
            //this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promocion>> Get(int id)
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
        public async Task<ActionResult<int>> Post(CrearPromocionDTO entidadDTO)
        {
            try
            {
                

                Promocion entidad = mapper.Map<Promocion>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] Promocion entidad)
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

            dammy.Titulo = entidad.Titulo;
            dammy.Descripcion = entidad.Descripcion;
            dammy.FechaInicio = entidad.FechaInicio;
            dammy.FechaFin = entidad.FechaFin;
          




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
                return NotFound($"La promoción {id} no existe.");
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
