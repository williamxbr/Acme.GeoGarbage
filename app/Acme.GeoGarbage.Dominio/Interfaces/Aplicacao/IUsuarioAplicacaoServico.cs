using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IUsuarioAplicacaoServico : IAplicacaoServicoBase<Usuario>
    {
        Usuario BuscaPorEmail(string email);
        Usuario BuscaPorLoginSenha(string login, string senha);
    }
}