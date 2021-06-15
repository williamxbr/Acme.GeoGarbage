using System;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RetornoParaGaragem
    {
        [PrimaryKey]
        public Guid IdRetornoParaGaragem { get; set; }
        public Guid IdGaragem { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime DataHoraSelecaoGaragem { get; set; }
        public DateTime DataHoraInicioRetorno { get; set; }
        public double OdometroPartida { get; set; }
        public double HorimetroPartida { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public double OdometroChegada { get; set; }
        public double HorimetroChegada { get; set; }
        public bool EmViagem { get; set; }
        public TimeSpan TotalTempo { get; private set; }
        public double TotalOdometro { get; private set; }
        public double TotalHorimetro { get; private set; }
        [Ignore]
        public virtual Jornada Jornada { get; set; }
        [Ignore]
        public virtual Garagem Garagem { get; set; }

    }
}
