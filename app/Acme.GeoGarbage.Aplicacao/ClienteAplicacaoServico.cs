using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ClienteAplicacaoServico : AplicacaoServicoBase<Cliente>, IClienteAplicacaoServico
    {
        private readonly IClienteServico _clienteServico;

        public ClienteAplicacaoServico(IClienteServico clienteServico) : base(clienteServico)
        {
            _clienteServico = clienteServico;
        }
    }
}
