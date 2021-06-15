using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class SetorDaJornada
    {
        [PrimaryKey]
        public Guid IdSetorDaJornada { get; set; }
        public Guid IdSetor { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime DataHoraDoVinculoDoSetorNaJornada { get; set; }
        public DateTime DataHoraInicioSetor { get; set; }
        public double OdometroInicioSetor { get; set; }
        public double HorimetroInicioSetor { get; set; }
        public DateTime DataHoraEncerramentoSetor { get; set; }
        public double OdometroNoEncerramentoDoSetor { get; set; }
        public double HorimetroNoEncerramentoDoSetor { get; set; }
        public TimeSpan TempoSetorDaJornada { get; private set; }
        public double TotalOdometro { get; private set; }
        public double TotalHorimetro { get; private set; }
        public virtual Jornada Jornada { get; set; }
        [Ignore]
        public virtual Setor Setor { get; set; }
        [Ignore]
        public virtual IEnumerable<RetornoParaCompletarColeta> RetornoParaCompletarColetas { get; set; }
        [Ignore]
        public virtual IEnumerable<DescargaDeColeta> DescargaDeColetas { get; set; }
        public StatusDeOperacao Status { get; set; }
        [Ignore]
        public virtual IEnumerable<ExecucaoPontoDeColeta> ExecucaoPontoDeColetas { get; set; }
    }
}
