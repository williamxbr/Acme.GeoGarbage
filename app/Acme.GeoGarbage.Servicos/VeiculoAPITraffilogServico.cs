using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class VeiculoAPITraffilogServico : ServicoBase<VeiculoAPITraffilog>, IVeiculoAPITraffilogServico
    {
        private readonly IVeiculoAPITraffilogRepositorio _veiculoApiTraffilogRepositorio;

        public VeiculoAPITraffilogServico(IVeiculoAPITraffilogRepositorio veiculoApiTraffilogRepositorio)
            : base(veiculoApiTraffilogRepositorio)
        {
            _veiculoApiTraffilogRepositorio = veiculoApiTraffilogRepositorio;
        }
    }
}