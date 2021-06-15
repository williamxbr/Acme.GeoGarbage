using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class PadraoDaContaServico : ServicoBase<PadraoDaConta>, IPadraoDaContaServico
    {
        private readonly IPadraoDaContaRepositorio _padraodacontaRepositorio;

        public PadraoDaContaServico(IPadraoDaContaRepositorio padraodacontaRepositorio) : base(padraodacontaRepositorio)
        {
            _padraodacontaRepositorio = padraodacontaRepositorio;
        }
    }
}
