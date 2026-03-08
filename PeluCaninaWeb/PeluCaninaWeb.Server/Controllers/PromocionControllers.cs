using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion")]

    public class PromocionControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;


        #region constructor
        public PromocionControllers(Context context, 
                                    IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion>>> Get()
        {
            return await context.Promocion.ToListAsync();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promocion>> Get(int id)
        {
            Promocion? pepe = await context.Promocion
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pepe == null)
            {
                return NotFound($"La promocion {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPromocionDTO entidadDTO)
        {

            try
            {
                Promocion entidad = mapper.Map<Promocion>(entidadDTO);


                //Promocion entidad = new Promocion();

                //entidad.Titulo = entidadDTO.Titulo;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.FechaInicio = entidadDTO.FechaInicio;
                //entidad.FechaFin = entidadDTO.FechaFin;
                //entidad.Activo = entidadDTO.Activo;

                context.Promocion.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Promocion entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await context.Promocion.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Servicio no encontrada");
            }

            dammy.Titulo = entidad.Titulo;
            dammy.Descripcion = entidad.Descripcion;
            dammy.FechaInicio = entidad.FechaInicio;
            dammy.FechaFin = entidad.FechaFin;
            dammy.Activo = entidad.Activo;


            try
            {
                context.Promocion.Update(dammy);
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
            var existe = await context.Promocion.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La promocion {id}, no existe");
            }

            Promocion entidadBorrar = new Promocion();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);

            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
