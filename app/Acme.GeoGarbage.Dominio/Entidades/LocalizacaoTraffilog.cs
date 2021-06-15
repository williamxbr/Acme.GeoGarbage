using System;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class LocalizacaoTraffilog
    {
        public int IdLocalizacaoTraffilog { get; set; }
        public long IdViagemTraffilog { get; set; }
        public Guid IdVeiculo { get; set; }
        public DateTime Time { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Odometro { get; set; }
        public VehicleStatus StatusVeiculo { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual ViagemTraffilog ViagemTraffilog { get; set; }
    }
}