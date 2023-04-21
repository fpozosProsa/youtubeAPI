using System.ComponentModel.DataAnnotations;

namespace youtubeAPI.Modelos.Dto.Empresa
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public int Ocupantes { get; set; }
        public int Metros { get; set; }
    }
}
