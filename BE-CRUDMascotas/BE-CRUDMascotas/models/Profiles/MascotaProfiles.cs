using AutoMapper;
using BE_CRUDMascotas.models.DTO;

namespace BE_CRUDMascotas.models.Profiles
{
    public class MascotaProfiles: Profile
    {
        public MascotaProfiles() 
        {
            CreateMap<Mascota, MascotaDTO>();
            CreateMap<MascotaDTO, Mascota>();
        }
    }
}
