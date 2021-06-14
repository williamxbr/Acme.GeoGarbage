using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RetornoParaCompletarColeta
    {
        public Guid IdRecursoDeColeta { get; set; }
        public Guid IdSetorJornada { get; set; }
        public DateTime DataHoraRetorno { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        public virtual SetoresDaJornada SetoresDaJornada { get; set; }

    }
}
