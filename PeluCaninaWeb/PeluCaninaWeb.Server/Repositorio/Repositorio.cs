using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class Repositorio<E> :  IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context context;

        #region constructor
        public Repositorio(Context context)
        {
            this.context = context;
        }
        #endregion

        #region Select
        public async Task<List<E>> Select() //Task == "Tarea"
        {
            return await context.Set<E>().ToListAsync();
        }
        #endregion

        #region Insert
        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync(); //espera y guarda los cambios del context
                return entidad.Id; //Id de la entidad 
            }
            catch (Exception Err)
            {
                //return BadRequest(ErrorMessage.Message);
                throw Err;
            }
        }
        #endregion

        #region Update
        public async Task<bool> Update(int id, E entidad)
        {
            if (id == entidad.Id)
            {
                return false;
            }


            var Lean = await SelectById(id);



            if (Lean == null)
            {
                return false;
            }



            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception err)
            {

                throw err;
            }
        }
        #endregion

        #region SelectById
        public async Task<E> SelectById(int id)
        {
            E? lean = await context.Set<E>().AsNoTracking() // AsNoTracking() == (Para evitar que no quede en memoria)
                .FirstOrDefaultAsync(x => x.Id == id);

            return lean;
        }
        #endregion

        #region Borrar
        public async Task<bool> Borrar(int id)
        {                                            //(expresión en lambda)
            var lean = await SelectById(id);

            if (lean == null)
            {
                return false;
            }

            context.Set<E>().Remove(lean);
            await context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Existe
        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>().AnyAsync(x => x.Id == id);
            return existe;
        }
        #endregion

    }
}
