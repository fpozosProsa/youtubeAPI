using Microsoft.AspNetCore.Identity;

namespace youtubeAPI.Modelos
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
