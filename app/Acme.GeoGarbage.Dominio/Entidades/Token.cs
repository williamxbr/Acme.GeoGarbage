using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Token
    {
        public int IdToken { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid AutorizeToken { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Expira { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
