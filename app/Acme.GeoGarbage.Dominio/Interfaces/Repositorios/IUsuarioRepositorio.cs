using System.Runtime.Remoting.Messaging;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario BuscaPorEmail(string email);
        Usuario BuscaPorLoginSenha(string login, string senha);
    }
}