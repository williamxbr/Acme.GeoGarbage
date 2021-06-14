using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DescargaDeColeta
    {
        public Guid IdDescargaDeColetas { get; set; }
        public Guid IdSetorJornada { get; set; }
        public Guid IdDescargaAterro { get; set; }
        public double PesoEstimadoDescarregado { get; set; }
        public virtual SetoresDaJornada SetoresDaJornada { get; set; }
        public virtual DescargaAterro DescargaAterro { get; set; }

    }
}
