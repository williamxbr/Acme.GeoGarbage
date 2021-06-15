using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class PontoDeColetaAplicacaoServico : AplicacaoServicoBase<PontoDeColeta>, IPontoDeColetaAplicacaoServico
    {
        private readonly IPontoDeColetaServico _pontodecoletaServico;

        public PontoDeColetaAplicacaoServico(IPontoDeColetaServico pontodecoletaServico) : base(pontodecoletaServico)
        {
            _pontodecoletaServico = pontodecoletaServico;
        }
    }
}
