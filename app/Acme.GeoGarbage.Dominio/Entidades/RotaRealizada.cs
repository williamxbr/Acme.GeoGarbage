using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RotaRealizada
    {
        public Guid IdJornada { get; set; }
        public DateTime Ping { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual Jornada Jornada { get; set; }
    }
}
