using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Servicio")]

    public class ServicioControllers : ControllerBase
    {
        private readonly Context context;

        #region constructor
        public ServicioControllers(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            return await context.Servicio.ToListAsync();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Servicio>> Get(int id)
        {
            Servicio? pepe = await context.Servicio
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pepe == null)
            {
                return NotFound($"El servicio {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Servicio entidad)
        {

            try
            {
                context.Servicio.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Servicio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await context.Servicio.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("Servicio no encontrada");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Descripcion = entidad.Descripcion;
            dammy.Precio = entidad.Precio;


            try
            {
                context.Servicio.Update(dammy);
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
            var existe = await context.Servicio.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El servicio {id}, no existe");
            }

            Servicio entidadBorrar = new Servicio();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);

            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}


