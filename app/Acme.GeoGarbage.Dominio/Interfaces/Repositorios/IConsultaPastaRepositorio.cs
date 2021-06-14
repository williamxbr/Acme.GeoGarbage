using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Repositorios
{
    public interface IConsultaPastaRepositorio : IRepositorioBase<ConsultaPasta>
    {
        ConsultaPasta BuscaPorPasta(string pasta);
    }
}