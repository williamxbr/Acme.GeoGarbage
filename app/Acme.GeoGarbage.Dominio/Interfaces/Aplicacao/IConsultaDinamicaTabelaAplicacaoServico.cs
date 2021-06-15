using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IConsultaDinamicaTabelaAplicacaoServico : IAplicacaoServicoBase<ConsultaDinamicaTabela>
    {
        void RemoveTodosConsultaDinamicaTabela(ConsultaDinamica consultaDinamica);
    }
}