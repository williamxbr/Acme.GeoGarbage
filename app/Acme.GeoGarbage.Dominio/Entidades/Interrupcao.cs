using System;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Interrupcao
    {
        [PrimaryKey]
        public Guid IdInterrupcao { get; set; }  
        public DateTime DataHoraInterrupcao { get; set; }
        public DateTime DataHoraFimInterrupcao { get; set; }
        public Guid IdVeiculo { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        public Guid IdMotivoInterrupcao { get; set; }
        public TimeSpan TempoInterrupcao { get; private set; }
        [Ignore]
        public virtual MotivoInterrupcao MotivosInterrupcao { get; set; }
        [Ignore]
        public virtual Veiculo Veiculo { get; set; }
    }
}
