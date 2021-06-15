using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class RotaRealizadaConfig : EntityTypeConfiguration<RotaRealizada>
    {
        public RotaRealizadaConfig()
        {
            HasKey(t => t.IdRotaRealizada);

            Property(t => t.IdRotaRealizada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Jornada)
                .WithMany()
                .HasForeignKey(t => t.IdJornada);

            Property(p => p.ChecouPonto)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_RotaRealizada_ChecouPonto")));
        }
    }
}
