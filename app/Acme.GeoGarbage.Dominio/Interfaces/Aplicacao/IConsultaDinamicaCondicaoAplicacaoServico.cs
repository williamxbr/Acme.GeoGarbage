using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IConsultaDinamicaCondicaoAplicacaoServico : IAplicacaoServicoBase<ConsultaDinamicaCondicao>
    {
        void RemoveTodosConsultaDinamicaCondicao(ConsultaDinamica consultaDinamica);
    }
}