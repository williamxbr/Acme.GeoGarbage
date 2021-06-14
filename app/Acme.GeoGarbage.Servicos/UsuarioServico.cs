using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario BuscaPorEmail(string email)
        {
            return _usuarioRepositorio.BuscaPorEmail(email);
        }

        public Usuario BuscaPorLoginSenha(string login, string senha)
        {
            return _usuarioRepositorio.BuscaPorLoginSenha(login, senha);
        }

    }
}