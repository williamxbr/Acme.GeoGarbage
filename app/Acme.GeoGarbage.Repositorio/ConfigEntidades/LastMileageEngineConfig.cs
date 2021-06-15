using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class LastMileageEngineConfig : EntityTypeConfiguration<LastMileageEngine>
    {
        public LastMileageEngineConfig()
        {
            HasKey(p => p.IdLastMileageEngine);

            Property(p => p.IdLastMileageEngine)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.StatusIntegracao)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_LastMileageEngine_StatusIntegracao")));

        }
    }
}