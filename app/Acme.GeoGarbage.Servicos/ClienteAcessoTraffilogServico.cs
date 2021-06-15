using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ClienteAcessoTraffilogServico : ServicoBase<ClienteAcessoTraffilog>, IClienteAcessoTraffilogServico
    {
        private readonly IClienteAcessoTraffilogRepositorio _clienteAcessoTraffilogRepositorio;

        public ClienteAcessoTraffilogServico(IClienteAcessoTraffilogRepositorio clienteAcessoTraffilogRepositorio) : base(clienteAcessoTraffilogRepositorio)
        {
            _clienteAcessoTraffilogRepositorio = clienteAcessoTraffilogRepositorio;
        }
    }
}