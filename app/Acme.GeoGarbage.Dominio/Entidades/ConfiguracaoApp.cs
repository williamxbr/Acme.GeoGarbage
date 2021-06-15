using System;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConfiguracaoApp
    {
        [PrimaryKey]
        public int IdConfiguracaoApp { get; set; }
        public Guid IdCliente { get; set; }
        public bool ValidaMotorista { get; set; }
        public bool ValidaColetor { get; set; }
        public bool ValidarPeso { get; set; }
        [Ignore]
        public virtual Cliente Clientes { get; set; }

    }
}
