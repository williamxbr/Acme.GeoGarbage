using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class PontoDeColetaServico : ServicoBase<PontoDeColeta>, IPontoDeColetaServico
    {
        private readonly IPontoDeColetaRepositorio _pontodecoletaRepositorio;

        public PontoDeColetaServico(IPontoDeColetaRepositorio pontodecoletaRepositorio) : base(pontodecoletaRepositorio)
        {
            _pontodecoletaRepositorio = pontodecoletaRepositorio;
        }
    }
}
