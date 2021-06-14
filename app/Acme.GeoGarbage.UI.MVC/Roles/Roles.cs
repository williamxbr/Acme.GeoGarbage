using System.Web.Security;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Roles
{
    public class Roles : RoleProvider
    {

        private readonly IUsuarioAplicacaoServico _usuarioAplicacaoServico;

        public Roles(IUsuarioAplicacaoServico usuarioAplicacaoServico)
        {
            _usuarioAplicacaoServico = usuarioAplicacaoServico;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            //var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioAplicacaoServico.BuscaTodos());

            //ContextDB db = new ContextDB();

            //USUARIO usuario = db.USUARIO.FirstOrDefault(u => u.NOME_USUARIO == username);

            //if (usuario == null)
            //    return new string[] { };

            //List<string> permissoes = new List<string>();

            //switch (usuario.TIPO_USUARIO)
            //{
            //    case eTipoUsuario.Administrador:
            //        permissoes.Add("Administrador");
            //        break;
            //    case eTipoUsuario.Gerencia:
            //        permissoes.Add("Gerencia");
            //        break;
            //    case eTipoUsuario.PCP:
            //        permissoes.Add("PCP");
            //        break;
            //    case eTipoUsuario.Operador:
            //        permissoes.Add("Operador");
            //        break;
            //}

            //return permissoes.ToArray();

            throw new System.NotImplementedException();

        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}