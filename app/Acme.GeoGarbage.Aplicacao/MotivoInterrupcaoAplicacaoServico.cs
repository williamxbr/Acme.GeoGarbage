using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class MotivoInterrupcaoAplicacaoServico : AplicacaoServicoBase<MotivoInterrupcao>, IMotivoInterrupcaoAplicacaoServico
    {
        private readonly IMotivoInterrupcaoServico _motivosInterrupcaoServico;

        public MotivoInterrupcaoAplicacaoServico(IMotivoInterrupcaoServico motivosInterrupcaoServico) : base(motivosInterrupcaoServico)
        {
            _motivosInterrupcaoServico = motivosInterrupcaoServico;
        }
    }
}
