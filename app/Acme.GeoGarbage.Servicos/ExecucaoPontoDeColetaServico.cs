using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ExecucaoPontoDeColetaServico : ServicoBase<ExecucaoPontoDeColeta>, IExecucaoPontoDeColetaServico
    {
        private readonly IExecucaoPontoDeColetaRepositorio _execucaopontodecoletaRepositorio;

        public ExecucaoPontoDeColetaServico(IExecucaoPontoDeColetaRepositorio execucaopontodecoletaRepositorio) : base(execucaopontodecoletaRepositorio)
        {
            _execucaopontodecoletaRepositorio = execucaopontodecoletaRepositorio;
        }
    }
}
