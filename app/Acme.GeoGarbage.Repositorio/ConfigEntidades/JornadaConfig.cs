using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class JornadaConfig : EntityTypeConfiguration<Jornada>
    {
        public JornadaConfig()
        {
            HasKey(t => t.IdJornada);

            Property(t => t.IdJornada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Veiculo)
                .WithMany()
                .HasForeignKey(t => t.IdVeiculo);

            Property(t => t.TempoJornada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalHorimetro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalOdometro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(p => p.OdometroInicial)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Jornada_OdometroInicial")));

            Property(p => p.OdometroFinal)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Jornada_OdometroFinal")));
        }
    }
}
