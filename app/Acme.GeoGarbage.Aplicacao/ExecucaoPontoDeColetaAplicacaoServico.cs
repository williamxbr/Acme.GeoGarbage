using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ExecucaoPontoDeColetaAplicacaoServico : AplicacaoServicoBase<ExecucaoPontoDeColeta>, IExecucaoPontoDeColetaAplicacaoServico
    {
        private readonly IExecucaoPontoDeColetaServico _execucaopontodecoletaServico;

        public ExecucaoPontoDeColetaAplicacaoServico(IExecucaoPontoDeColetaServico execucaopontodecoletaServico) : base(execucaopontodecoletaServico)
        {
            _execucaopontodecoletaServico = execucaopontodecoletaServico;
        }
    }
}
