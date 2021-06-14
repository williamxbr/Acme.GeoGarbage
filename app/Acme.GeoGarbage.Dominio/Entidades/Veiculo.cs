using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Veiculo
    {
        public Guid IdVeiculo { get; set; }
        public string IdentificacaoNoCliente { get; set; }
        public Guid IdCliente { get; set; }
        public bool Ativo { get; set; }
        public virtual Cliente Clientes { get; set; }
        public virtual IEnumerable<Interrupcao> Interrupcoes { get; set; }
        public virtual IEnumerable<Jornada> Jornadas { get; set; }
        public virtual IEnumerable<DeviceInstalado> DeviceInstalados { get; set; }

    }
}
