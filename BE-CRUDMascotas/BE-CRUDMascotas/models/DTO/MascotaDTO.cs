namespace BE_CRUDMascotas.models.DTO
{
    public class MascotaDTO
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public string especie { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int iddueño { get; set; }
    }
}
