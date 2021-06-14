using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class SelecaoDeNovoSetor
    {
        public Guid IdNovoSetor { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime DataHoraSelecao { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        public virtual Jornada Jornada { get; set; }

    }
}
