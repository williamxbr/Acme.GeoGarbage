using System;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RotaRealizada
    {
        [PrimaryKey]
        public  int IdRotaRealizada { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime Ping { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool ChecouPonto { get; set; }
        [Ignore]
        public virtual Jornada Jornada { get; set; }
    }
}
