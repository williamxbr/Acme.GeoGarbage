using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Interrupcao
    {
        public Guid IdInterrupcao { get; set; }  
        public DateTime DataHoraInterrupcao { get; set; }
        public DateTime DataHoraFimInterrupcao { get; set; }
        public Guid IdVeiculo { get; set; }
        public double Odometro { get; set; }
        public double Horimetro { get; set; }
        public Guid IdJornada { get; set; }
        public Guid IdMotivoInterrupcao { get; set; }
        public virtual MotivosInterrupcao MotivosInterrupcao { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual Jornada Jornada { get; set; }

    }
}
