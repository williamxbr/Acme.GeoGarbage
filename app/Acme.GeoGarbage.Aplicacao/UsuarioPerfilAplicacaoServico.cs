using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class UsuarioPerfilAplicacaoServico : AplicacaoServicoBase<UsuarioPerfil>, IUsuarioPerfilAplicacaoServico
    {
        private readonly IUsuarioPerfilServico _usuariosperfilServico;

        public UsuarioPerfilAplicacaoServico(IUsuarioPerfilServico usuariosperfilServico) : base(usuariosperfilServico)
        {
            _usuariosperfilServico = usuariosperfilServico;
        }
    }
}
