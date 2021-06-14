using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.Infrastructure.Annotations;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConsultaDinamicaConfig : EntityTypeConfiguration<ConsultaDinamica>
    {
        public ConsultaDinamicaConfig()
        {
            HasKey(f => f.IdConsultaDinamica);

            Property(f => f.IdConsultaDinamica)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(f => f.NomeConsultaDinamica)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            HasRequired(f => f.ConsultaPasta)
                .WithMany()
                .HasForeignKey(f => f.IdConsultaPasta);

        }
    }
}