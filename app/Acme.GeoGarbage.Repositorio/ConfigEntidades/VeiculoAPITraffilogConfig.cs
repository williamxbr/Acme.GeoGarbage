using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class VeiculoAPITraffilogConfig : EntityTypeConfiguration<VeiculoAPITraffilog>
    {
        public VeiculoAPITraffilogConfig()
        {
            HasKey(p => p.IdVeiculo);

            Property(p => p.IdVeiculo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(v1 => v1.Veiculo)
                .WithOptional(v2 => v2.VeiculoApiTraffilogs);
        }
    }
}