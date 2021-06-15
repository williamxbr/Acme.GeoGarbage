using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IConsultaDinamicaAssociacaoAplicacaoServico : IAplicacaoServicoBase<ConsultaDinamicaAssociacao>
    {
        void RemoveTodosConsultaDinamicaAssociacao(ConsultaDinamica consultaDinamica);
    }
}