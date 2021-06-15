using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class PadraoDaContaAplicacaoServico : AplicacaoServicoBase<PadraoDaConta>, IPadraoDaContaAplicacaoServico
    {
        private readonly IPadraoDaContaServico _padraodacontaServico;

        public PadraoDaContaAplicacaoServico(IPadraoDaContaServico padraodacontaServico) : base(padraodacontaServico)
        {
            _padraodacontaServico = padraodacontaServico;
        }
    }
}
