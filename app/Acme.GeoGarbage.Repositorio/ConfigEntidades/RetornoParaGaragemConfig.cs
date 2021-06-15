using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class RetornoParaGaragemConfig : EntityTypeConfiguration<RetornoParaGaragem>
    {
        public RetornoParaGaragemConfig()
        {
            HasKey(t => t.IdRetornoParaGaragem);

            Property(t => t.IdRetornoParaGaragem)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Garagem)
                .WithMany()
                .HasForeignKey(t => t.IdGaragem);

            HasRequired(t => t.Jornada)
                .WithMany()
                .HasForeignKey(t => t.IdJornada);

            Property(t => t.TotalTempo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalHorimetro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalOdometro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

        }
    }
}
