using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ViagemTraffilog
    {
        public long IdViagemTraffilog { get; set; }
        public Guid IdVeiculo { get; set; }
        public DateTime InicioViagem { get; set; }
        public DateTime FimViagem { get; set; }
        public DateTime InicioViagemUTC { get; set; }
        public DateTime FimViagemUTC { get; set; }
        public double InicioLatitude { get; set; }
        public double FimLatitude { get; set; }
        public double InicioLongitude { get; set; }
        public double FimLongitude { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual IEnumerable<LocalizacaoTraffilog> LocalizacaoTraffilogs { get; set; }

    }
}