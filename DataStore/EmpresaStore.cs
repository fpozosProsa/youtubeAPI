using youtubeAPI.Modelos.Dto.Empresa;

namespace youtubeAPI.DataStore
{
    public static class EmpresaStore
    {
        public static List<EmpresaDto> EmpresaList = new List<EmpresaDto>
        {
            new EmpresaDto{Id=1, Nombre="Televisa"},
            new EmpresaDto{Id=2, Nombre="Pemex"},
            new EmpresaDto{Id=3, Nombre="PROSA"}
        };
    }
}
