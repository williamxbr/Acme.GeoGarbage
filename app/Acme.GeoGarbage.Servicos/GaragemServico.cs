using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class GaragemServico : ServicoBase<Garagem>, IGaragemServico
    {
        private readonly IGaragemRepositorio _garagemRepositorio;

        public GaragemServico(IGaragemRepositorio garagemRepositorio) : base(garagemRepositorio)
        {
            _garagemRepositorio = garagemRepositorio;
        }
    }
}
