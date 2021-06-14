using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IServicoBase<Usuario>
    {
        Usuario BuscaPorEmail(string email);
        Usuario BuscaPorLoginSenha(string login, string senha);
    }
}