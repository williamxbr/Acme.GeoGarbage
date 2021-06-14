using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IConsultaPastaAplicacaoServico : IAplicacaoServicoBase<ConsultaPasta>
    {
        ConsultaPasta BuscaPorPasta(string pasta);
    }
}