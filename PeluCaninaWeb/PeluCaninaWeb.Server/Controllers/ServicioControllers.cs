using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Servicio")]

    public class ServicioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region constructor
        public ServicioControllers(Context context, 
                                   IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            return await context.Servicio.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Servicio>> Get(int id)
        {
            var dammy = await context.Servicio.FirstOrDefaultAsync(x => x.Id == id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearServicioDTO entidadDTO)
        {
            try
            {
                //Servicio entidad = new Servicio();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.Precio = entidadDTO.Precio;

                Servicio entidad = mapper.Map<Servicio>(entidadDTO);

                context.Servicio.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Servicio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Servicio.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró el servicio");
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
            var existe = await context.Servicio.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El servicio {id} no existe.");
            }

            Servicio EntidadAborrar = new Servicio();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"El servicio {id} fue eliminado correctamente.");
        }
        #endregion
    }
}
