using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IConsultaDinamicaCampoAplicacaoServico : IAplicacaoServicoBase<ConsultaDinamicaCampo>
    {
        void RemoveTodosConsultaDinamicaCampo(ConsultaDinamica consultaDinamica);
    }
}