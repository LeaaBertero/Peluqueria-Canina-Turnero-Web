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
    [Route("api/Servicio")]

    public class ServicioControllers : ControllerBase
    {
        //private readonly Context context;
        private readonly IServicioRepositorio repositorio;
        private readonly IMapper mapper;


        #region constructor
        public ServicioControllers(IServicioRepositorio repositorio, 
                                   IMapper mapper)
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Servicio>> Get(int id)
        {
            Servicio? pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound($"El servicio {id} no existe");
            }
            return pepe;
        }
        #endregion

        #region Metodo Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearServicioDTO entidadDTO)
        {

            try
            {
                Servicio entidad = mapper.Map<Servicio>(entidadDTO);



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
        public async Task<ActionResult> Put(int id, [FromBody] Servicio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }


            //expresión lambda para buscar el id
            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("Servicio no encontrada");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Descripcion = entidad.Descripcion;
            dammy.Precio = entidad.Precio;
            

            try
            {
                await repositorio.Update(id, dammy);


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
            var existe = await repositorio.Existe(id);

            if (!existe == null)
            {
                return NotFound($"El servicio {id} no encontrado");
            }
            if (await repositorio.Borrar(id))
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


