using System;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Classes
{
    public class RetornoConfiguracaoDevice
    {
        public StatusConfiguracaoDevice Status { get; set; }
        public Guid IdVeiculo { get; set; }
    }
}