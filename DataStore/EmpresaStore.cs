using youtubeAPI.Modelos.Dto.Empresa;

namespace youtubeAPI.DataStore
{
    public static class EmpresaStore
    {
        public static List<EmpresaDto> EmpresaList = new List<EmpresaDto>
        {
            new EmpresaDto{Id=1, Nombre="Televisa", Ocupantes=3, Metros=40},
            new EmpresaDto{Id=2, Nombre="Pemex", Ocupantes=4, Metros=50},
            new EmpresaDto{Id=3, Nombre="PROSA", Ocupantes=6, Metros=80}
        };
    }
}
