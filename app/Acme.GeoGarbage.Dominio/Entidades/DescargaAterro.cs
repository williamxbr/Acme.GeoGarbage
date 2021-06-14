using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DescargaAterro
    {
        public Guid IdDescargaAterro { get; set; }
        public DateTime InicioDaViagemParaDescarga { get; set; }
        public double OdometroInicioDaViagemParaDescarga { get; set; }
        public double HorimetroInicioDaViagemParaDescarga { get; set; }
        public DateTime InicioDescargaAterro { get; set; }
        public DateTime InicioDescargaAterroOdometro { get; set; }
        public double InicioDescargaAterroHorimetro { get; set; }
        public DateTime DataHoraRegistroDoPeso { get; set; }
        public double PesoDaDescarga { get; set; }
        public bool EmViagem { get; set; }
        public DateTime DataHoraRegistroRecibo { get; set; }
        public int Recibo { get; set; }
        public virtual IEnumerable<DescargaDeColeta> DescargasDeColetas { get; set; }
    }
}
