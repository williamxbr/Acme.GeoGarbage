using System;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class SelecaoDeNovoSetor
    {
        [PrimaryKey]
        public Guid IdSelecaoDeNovoSetor { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime DataHoraSelecao { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        [Ignore]
        public virtual Jornada Jornada { get; set; }

    }
}
