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

        public PromocionControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Promocion>>> Get()
        {
            return await context.Promocion.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Promocion>> Get(int id)
        {
            var dammy = await context.Promocion.FirstOrDefaultAsync(x => x.Id == id);

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

                Promocion entidad = new Promocion();

                entidad.Titulo = entidadDTO.Titulo;
                entidad.Descripcion = entidadDTO.Descripcion;
                entidad.FechaInicio = entidadDTO.FechaInicio;
                entidad.FechaFin = entidadDTO.FechaFin;

                context.Promocion.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Promocion entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Promocion.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró la promoción");
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
            var existe = await context.Promocion.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La promoción {id} no existe.");
            }

            Promocion EntidadAborrar = new Promocion();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"La promoción {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
