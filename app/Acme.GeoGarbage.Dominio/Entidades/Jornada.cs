using System;
using System.Collections.Generic;
using static Acme.GeoGarbage.Dominio.Enums.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Jornada
    {
        public Guid IdJornada { get; set; }
        public DateTime InicioJornada { get; set; }
        public int IdVeiculo { get; set; }
        public double OdometroInicial { get; set; }
        public double HorimetroInicial { get; set; }
        public DateTime FimDaJornada { get; set; }
        public double OdometroFinal { get; set; }
        public double HorimetroFinal { get; set; }
        public EStatusJornada Status { get; set; }
        public DateTime DescargaPendente { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual IEnumerable<SetoresDaJornada> SetoresDasJornadas { get; set; }
        public virtual IEnumerable<RetornoParaGaragem> RetornoParaGaragens { get; set; }
        public virtual IEnumerable<SelecaoDeNovoSetor> SelecoesDeNovosSetores { get; set; }
        public virtual IEnumerable<RotaRealizada> RotasRealizadas { get; set; }
        public virtual IEnumerable<RecursosDaJornada> RecursosDasJornadas { get; set; }

    }
}
