using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Veiculo
    {
        [PrimaryKey]
        public Guid IdVeiculo { get; set; }
        public string IdentificacaoNoCliente { get; set; }
        public Guid IdCliente { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual Cliente Clientes { get; set; }
        [Ignore]
        public virtual IEnumerable<Interrupcao> Interrupcoes { get; set; }
        [Ignore]
        public virtual IEnumerable<Jornada> Jornadas { get; set; }
        [Ignore]
        public virtual IEnumerable<DeviceInstalado> DeviceInstalados { get; set; }
        [Ignore]
        public virtual VeiculoAPITraffilog VeiculoApiTraffilogs { get; set; }

    }
}
