using System;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DescargaDeColeta
    {
        [PrimaryKey]
        public Guid IdDescargaDeColeta { get; set; }
        public Guid IdDescargaAterro { get; set; }
        public Guid IdSetorJornada { get; set; }
        public double PesoEstimadoDescarregado { get; set; }
        [Ignore]
        public virtual SetorDaJornada SetorDaJornada { get; set; }
        [Ignore]
        public virtual DescargaAterro DescargaAterro { get; set; }

    }
}
