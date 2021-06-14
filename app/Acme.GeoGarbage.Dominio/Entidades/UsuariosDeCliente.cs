using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class UsuariosDeCliente
    {
        public Guid IdCliente { get; set; }
        public Guid IdUsuario { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}