using AutoMapper;
using PeluCaninaWeb.BD.Data.Entity;
using PeluCaninaWeb.Shared.DTO;

namespace PeluCaninaWeb.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearMascotaDTO, Mascota>();
            CreateMap<Mascota, CrearMascotaDTO>();

            CreateMap<CrearPromocionDTO, Promocion>();
            CreateMap<Promocion, CrearPromocionDTO>();

            CreateMap<CrearServicioDTO, Servicio>();
            CreateMap<Servicio, CrearServicioDTO>();

            CreateMap<CrearTurnoDTO, Turno>();
            CreateMap<Turno, CrearTurnoDTO>();

            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<Usuario, CrearUsuarioDTO>();
        }
    }
}
