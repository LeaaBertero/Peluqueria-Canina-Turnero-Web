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

        #region constructor
        public TurnoControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Get()
        {
            return await context.Turno.ToListAsync();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> Get(int id)
        {
            Turno? pepe = await context.Turno
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pepe == null)
            {
                return NotFound($"El turno {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTurnoDTO entidadDTO)
        {

            try
            {
                Turno entidad = new Turno();

                entidad.FechaHora = entidadDTO.FechaHora;
                entidad.Nota = entidadDTO.Nota;

                context.Turno.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Turno entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await context.Turno.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Turno no encontrada");
            }

            dammy.FechaHora = entidad.FechaHora;
            dammy.Nota = entidad.Nota;
            

            try
            {
                context.Turno.Update(dammy);
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
            var existe = await context.Turno.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El turno {id}, no existe");
            }

            Turno entidadBorrar = new Turno();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);

            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
