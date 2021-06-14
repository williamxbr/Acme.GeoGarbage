using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class UsuarioAplicacaoServico : AplicacaoServicoBase<Usuario>, IUsuarioAplicacaoServico
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioAplicacaoServico(IUsuarioServico usuarioServico) : base(usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public Usuario BuscaPorEmail(string email)
        {
            return _usuarioServico.BuscaPorEmail(email);
        }

        public Usuario BuscaPorLoginSenha(string login, string senha)
        {
            return _usuarioServico.BuscaPorLoginSenha(login, senha);
        }

    }
}