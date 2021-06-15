using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class VeiculoAPITraffilog
    {
        public Guid IdVeiculo { get; set; }
        public DateTime UltimaIntegracao { get; set; }
        public virtual Veiculo Veiculo { get; set; }
    }
}