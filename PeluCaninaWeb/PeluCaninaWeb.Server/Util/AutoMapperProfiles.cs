using AutoMapper;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
       
            #region DTO Mascota
            CreateMap<CrearMascotaDTO, Mascota>();
            CreateMap<Mascota, CrearMascotaDTO>();
            #endregion
           
            #region DTO Promocion
            CreateMap<CrearPromocionDTO, Promocion>();
            CreateMap<Promocion, CrearPromocionDTO>();
            #endregion
            
            #region DTO Servicio
            CreateMap<CrearServicioDTO, Servicio>();
            CreateMap<Servicio, CrearServicioDTO>();
            #endregion

            #region DTO Turno
            CreateMap<CrearTurnoDTO, Turno>();
            CreateMap<Turno, CrearTurnoDTO>();
            #endregion

            #region DTO Usuario
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<Usuario, CrearUsuarioDTO>();
            #endregion
        }
    }
}
