namespace BE_CRUDMascotas.models.Repository
{
    public interface IMascotasRepository
    {
        Task<List<Mascota>> GetListMascotas();
        Task<Mascota> GetMascota(int id);
        Task deleteMascota(Mascota mascota);
        Task <Mascota> AddMascota (Mascota mascota);
        Task UpdateMascota(Mascota mascota);
    }
}
