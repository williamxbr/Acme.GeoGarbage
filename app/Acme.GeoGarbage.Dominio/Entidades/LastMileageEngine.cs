using System;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class LastMileageEngine
    {
        public int IdLastMileageEngine { get; set; }
        public DateTime DataImportacao { get; set; }
        public TipoMileageEngine Type { get; set; }
        public string LicenseNumber { get; set; }
        public int? VehicleId { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public bool StatusIntegracao { get; set; }
    }
}