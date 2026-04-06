using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Controllers
{
    [ApiController]
    [Route("api/Mascota")]

    public class MascotaControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public MascotaControllers(Context context, 
                                  IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> Get()
        {
            return await context.Mascota.ToListAsync();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Mascota>> Get(int id)
        {
            var dammy = await context.Mascota.FirstOrDefaultAsync(x => x.Id == id);

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
                //Mascota entidad = new Mascota();

                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Edad = entidadDTO.Edad;
                //entidad.Peso = entidadDTO.Peso;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.Especie = entidadDTO.Especie;
                //entidad.Raza = entidadDTO.Raza;

                Mascota entidad = mapper.Map<Mascota>(entidadDTO);

                context.Mascota.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Mascota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await context.Mascota.
                Where(e => e.Id == id).FirstOrDefaultAsync();

            if (dammy == null)
            {
                return NotFound("No se encontró la promoción");
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
            var existe = await context.Mascota.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La mascota {id} no existe.");
            }

            Mascota EntidadAborrar = new Mascota();

            EntidadAborrar.Id = id;

            context.Remove(EntidadAborrar);

            await context.SaveChangesAsync();

            return Ok($"La mascota {id} fue eliminada correctamente.");
        }
        #endregion
    }
}
