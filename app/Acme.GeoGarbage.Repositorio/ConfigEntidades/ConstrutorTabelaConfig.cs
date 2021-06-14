using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConstrutorTabelaConfig : EntityTypeConfiguration<ConstrutorTabela>
    {
        public ConstrutorTabelaConfig()
        {
            HasKey(f => f.IdConstrutorTabela);

            Property(f => f.IdConstrutorTabela)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(f => f.Apelido)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

        }
    }
}
