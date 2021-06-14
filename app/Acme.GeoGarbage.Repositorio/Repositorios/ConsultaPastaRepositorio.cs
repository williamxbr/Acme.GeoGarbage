using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class ConsultaPastaRepositorio : RepositorioBase<ConsultaPasta>, IConsultaPastaRepositorio
    {
        public ConsultaPasta BuscaPorPasta(string pasta)
        {
            return Db.ConsultaPasta.FirstOrDefault(p => p.NomePasta == pasta);
        }
    }
}