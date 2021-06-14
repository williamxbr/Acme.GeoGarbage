using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class DeviceInstalado
    {
        public int IdInstalacao { get; set; }
        public Guid IdDevice { get; set; }
        public Guid IdVeiculo { get; set; }
        public Guid IdUsuario { get; set; }
        public bool Ativo { get; set; }
        public virtual Device Device { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}
