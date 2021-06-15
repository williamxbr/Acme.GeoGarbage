using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class InterrupcaoConfig : EntityTypeConfiguration<Interrupcao>
    {
        public InterrupcaoConfig()
        {
            HasKey(t => t.IdInterrupcao);
            Property(t => t.IdInterrupcao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.MotivosInterrupcao)
                .WithMany()
                .HasForeignKey(t => t.IdMotivoInterrupcao);

            HasRequired(t => t.Veiculo)
                .WithMany()
                .HasForeignKey(t => t.IdVeiculo);

            Property(t => t.TempoInterrupcao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}
