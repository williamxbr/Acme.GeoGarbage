using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ViagemTraffilogConfig : EntityTypeConfiguration<ViagemTraffilog>
    {
        public ViagemTraffilogConfig()
        {
            HasKey(p => p.IdViagemTraffilog);

            Property(p => p.IdViagemTraffilog)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            HasRequired(t => t.Veiculo)
                .WithMany()
                .HasForeignKey(t => t.IdVeiculo);

        }
    }
}