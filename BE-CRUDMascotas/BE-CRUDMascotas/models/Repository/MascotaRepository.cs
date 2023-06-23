using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.models.Repository
{
    public class MascotaRepository: IMascotasRepository
    {
        private readonly AplicationDbContext _context;

        public MascotaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Mascota> AddMascota(Mascota mascota)
        {
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task deleteMascota(Mascota mascota)
        {
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Mascota>> GetListMascotas()
        {
            return await _context.Mascotas.ToListAsync();
        }

        public async Task<Mascota> GetMascota(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        public async Task UpdateMascota(Mascota mascota)
        {
            var mascotaItem = await _context.Mascotas.FirstOrDefaultAsync(x => x.Id == mascota.Id);

            if (mascotaItem != null)
            {
                mascotaItem.nombre = mascota.nombre;
                mascotaItem.especie = mascota.especie;
                mascotaItem.iddueño = mascota.iddueño;
                mascotaItem.fechanacimiento = mascota.fechanacimiento;
                mascotaItem.raza = mascota.raza;

                await _context.SaveChangesAsync();
            }

        }
    }
}
