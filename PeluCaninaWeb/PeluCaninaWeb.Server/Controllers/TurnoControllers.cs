using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Turno")]

    public class TurnoControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public TurnoControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Get()
        {
            return await context.Turno.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> Get(int id)
        {
            var dammy = await context.Turno.FirstOrDefaultAsync(x => x.Id == id);

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
                //Turno entidad = new Turno();

                //entidad.FechaHora = entidadDTO.FechaHora;
                //entidad.Nota = entidadDTO.Nota;

                Turno entidad = mapper.Map<Turno>(entidadDTO);

                context.Turno.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Turno entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Turno.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el registro");
            }

            dammy.FechaHora = entidad.FechaHora;
            dammy.Nota = entidad.Nota;
          
            


            try
            {
                context.Turno.Update(dammy);
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
            var existe = await context.Turno.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El turno {id} no existe.");
            }

            Turno EntidadAborrar = new Turno();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El turno {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
