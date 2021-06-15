using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class VeiculoServico : ServicoBase<Veiculo>, IVeiculoServico
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoServico(IVeiculoRepositorio veiculoRepositorio) : base(veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }
    }
}
