using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.Infrastructure.Annotations;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConsultaPastaConfig : EntityTypeConfiguration<ConsultaPasta>
    {
        public ConsultaPastaConfig()
        {
            HasKey(f => f.IdConsultaPasta);

            Property(f => f.IdConsultaPasta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(f => f.NomePasta)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
}