using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Mascota")]

    public class MascotaControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public MascotaControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> Get()
        {
            return await context.Mascota.ToListAsync();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mascota>> Get(int id)
        {
            Mascota? pepe = await context.Mascota
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pepe == null)
            {
                return NotFound($"La mascota {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Mascota entidad)
        {

            try
            {
                context.Mascota.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Mascota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await context.Mascota.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Servicio no encontrada");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Edad = entidad.Edad;
            dammy.Peso = entidad.Peso;
            dammy.Descripcion = entidad.Descripcion;
            dammy.Especie = entidad.Especie;
            dammy.Raza = entidad.Raza;


            try
            {
                context.Mascota.Update(dammy);
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
            var existe = await context.Mascota.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La mascota {id}, no existe");
            }

            Mascota entidadBorrar = new Mascota();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);

            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
