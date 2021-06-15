using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class LocalizacaoTraffilogConfig : EntityTypeConfiguration<LocalizacaoTraffilog>
    {
        public LocalizacaoTraffilogConfig()
        {
            HasKey(p => p.IdLocalizacaoTraffilog);

            Property(p => p.IdLocalizacaoTraffilog)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Veiculo)
                .WithMany()
                .HasForeignKey(t => t.IdVeiculo);

            HasRequired(p => p.ViagemTraffilog)
                .WithMany()
                .HasForeignKey(p => p.IdViagemTraffilog);

        }
    }
}