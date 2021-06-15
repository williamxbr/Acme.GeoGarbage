using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Jornada
    {
        [PrimaryKey]
        public Guid IdJornada { get; set; }
        public DateTime InicioJornada { get; set; }
        public Guid IdVeiculo { get; set; }
        public double OdometroInicial { get; set; }
        public double HorimetroInicial { get; set; }
        public DateTime FimDaJornada { get; set; }
        public double OdometroFinal { get; set; }
        public double HorimetroFinal { get; set; }
        public StatusJornada Status { get; set; }
        public DateTime DescargaPendente { get; set; }
        public TimeSpan TempoJornada { get; private set; }
        public double TotalOdometro { get; private set; }
        public double TotalHorimetro { get; private set; }
        [Ignore]
        public virtual Veiculo Veiculo { get; set; }
        [Ignore]
        public virtual IEnumerable<SetorDaJornada> SetorDasJornadas { get; set; }
        [Ignore]
        public virtual IEnumerable<RetornoParaGaragem> RetornoParaGaragens { get; set; }
        [Ignore]
        public virtual IEnumerable<SelecaoDeNovoSetor> SelecoesDeNovosSetores { get; set; }
        [Ignore]
        public virtual IEnumerable<RotaRealizada> RotasRealizadas { get; set; }
        [Ignore]
        public virtual IEnumerable<RecursoDaJornada> RecursosDasJornadas { get; set; }

    }
}
