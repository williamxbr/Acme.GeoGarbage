using System;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RetornoParaCompletarColeta
    {
        [PrimaryKey]
        public Guid IdRetornoParaCompletarColeta { get; set; }
        public Guid IdSetorJornada { get; set; }
        public DateTime DataHoraRetorno { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        [Ignore]
        public virtual SetorDaJornada SetorDaJornada { get; set; }

    }
}
