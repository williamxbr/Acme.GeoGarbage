using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual IEnumerable<UsuariosPerfil> UsuariosPerfils { get; set; }
    }
}