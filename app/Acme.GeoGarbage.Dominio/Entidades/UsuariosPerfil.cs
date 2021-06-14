using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class UsuariosPerfil
    {
        public Guid IdPerfilUsuario { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPerfil { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}