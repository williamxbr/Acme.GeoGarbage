using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class UsuarioPerfil
    {
        public int IdUsuarioPerfil { get; set; }
        public Guid IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}