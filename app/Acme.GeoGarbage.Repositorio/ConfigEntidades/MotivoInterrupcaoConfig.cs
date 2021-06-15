using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class MotivoInterrupcaoConfig : EntityTypeConfiguration<MotivoInterrupcao>
    {
        public MotivoInterrupcaoConfig()
        {
            HasKey(t => t.IdMotivoInterrupcao);

            Property(t => t.IdMotivoInterrupcao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
