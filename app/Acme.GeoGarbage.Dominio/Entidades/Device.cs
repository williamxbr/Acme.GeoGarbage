using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Device
    {
        public Guid IdDevice { get; set; }
        public string ChaveDevice { get; set; }
        public string ModeloDevice { get; set; }
        public virtual IEnumerable<DeviceInstalado> DevicesInstalados { get; set; }
    }
}
