using System;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DeviceInstalado
    {
        [PrimaryKey]
        public int IdInstalacao { get; set; }
        public Guid IdDevice { get; set; }
        public Guid IdVeiculo { get; set; }
        public Guid IdUsuario { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual Device Device { get; set; }
        [Ignore]
        public virtual Usuario Usuario { get; set; }
        [Ignore]
        public virtual Veiculo Veiculo { get; set; }
    }
}
