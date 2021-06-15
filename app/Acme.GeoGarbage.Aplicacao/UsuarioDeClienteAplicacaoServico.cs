using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class UsuarioDeClienteAplicacaoServico : AplicacaoServicoBase<UsuarioDeCliente>, IUsuarioDeClienteAplicacaoServico
    {
        private readonly IUsuarioDeClienteServico _usuariosdeclienteServico;

        public UsuarioDeClienteAplicacaoServico(IUsuarioDeClienteServico usuariosdeclienteServico) : base(usuariosdeclienteServico)
        {
            _usuariosdeclienteServico = usuariosdeclienteServico;
        }
    }
}
