using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RetornoParaGaragem
    {
        public Guid IdRetorno { get; set; }
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
        public virtual Jornada Jornada { get; set; }
        public virtual Garagem Garagem { get; set; }

    }
}
