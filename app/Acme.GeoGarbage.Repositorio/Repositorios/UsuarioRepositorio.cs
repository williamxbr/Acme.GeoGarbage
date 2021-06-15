using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using System;
using System.Data.Entity;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public override Usuario BuscaId(Guid id)
        {
            return Db.Usuarios
                     .Include(x => x.PadraoDaContas)     
                     .FirstOrDefault(x => x.IdUsuario == id);
        }

        public Usuario BuscaPorEmail(string email)
        {
            return Db.Usuarios.FirstOrDefault(p => p.Email == email);
        }

        public Usuario BuscaPorLoginSenha(string login, string senha)
        {
            return Db.Usuarios.FirstOrDefault(p => p.Login == login && p.Senha == senha);
        }
    }
}