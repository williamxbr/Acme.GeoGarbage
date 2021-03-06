using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Servicos
{
    public interface IConsultaPastaServico : IServicoBase<ConsultaPasta>
    {
        ConsultaPasta BuscaPorPasta(string pasta);
        IEnumerable<ConsultaPasta> BuscaTodosComItens();

    }
}