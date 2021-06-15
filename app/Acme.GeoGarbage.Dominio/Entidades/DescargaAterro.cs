using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DescargaAterro
    {
        [PrimaryKey]
        public Guid IdDescargaAterro { get; set; }
        public DateTime InicioDaViagemParaDescarga { get; set; }
        public double OdometroInicioDaViagemParaDescarga { get; set; }
        public double HorimetroInicioDaViagemParaDescarga { get; set; }
        public DateTime InicioDescargaAterro { get; set; }
        public double InicioDescargaAterroOdometro { get; set; }
        public double InicioDescargaAterroHorimetro { get; set; }
        public DateTime DataHoraRegistroDoPeso { get; set; }
        public double PesoDaDescarga { get; set; }
        public bool EmViagem { get; set; }
        public DateTime DataHoraRegistroRecibo { get; set; }
        public int Recibo { get; set; }
        [Ignore]
        public virtual IEnumerable<DescargaDeColeta> DescargaDeColetas { get; set; }
    }
}
