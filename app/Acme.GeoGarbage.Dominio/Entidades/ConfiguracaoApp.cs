using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConfiguracaoApp
    {
        public int IdConfiguracaoApp { get; set; }
        public Guid IdCliente { get; set; }
        public bool ValidaMotorista { get; set; }
        public bool ValidaColetor { get; set; }
        public bool ValidarPeso { get; set; }
        public virtual Cliente Clientes { get; set; }

    }
}
