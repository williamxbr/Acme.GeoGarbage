using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ClienteAcessoTraffilogAplicacaoServico : AplicacaoServicoBase<ClienteAcessoTraffilog>, IClienteAcessoTraffilogAplicacaoServico
    {
        private readonly IClienteAcessoTraffilogServico _clienteAcessoTraffilogServico;

        public ClienteAcessoTraffilogAplicacaoServico(IClienteAcessoTraffilogServico clienteAcessoTraffilogServico) : base(clienteAcessoTraffilogServico)
        {
            _clienteAcessoTraffilogServico = clienteAcessoTraffilogServico;
        }
    }
}