using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class SetoresDaJornada
    {
        public Guid IdSetorJornada { get; set; }
        public Guid IdSetor { get; set; }
        public Guid IdJornada { get; set; }
        public DateTime DataHoraDoVinculoDoSetorNaJornada { get; set; }
        public DateTime DataHoraInicioSetor { get; set; }
        public double OdometroInicioSetor { get; set; }
        public double HorimetroInicioSetor { get; set; }
        public DateTime DataHoraEncerramentoSetor { get; set; }
        public double OdometroNoEncerramentoDoSetor { get; set; }
        public double HorimetroNoEncerramentoDoSetor { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual IEnumerable<RetornoParaCompletarColeta> RetornoParaCompletasColetas { get; set; }
        public virtual IEnumerable<DescargaDeColeta> DescargaDeColetas { get; set; }
    }
}
