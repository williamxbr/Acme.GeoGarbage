using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(c => c.IdUsuario);

            Property(c => c.IdUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() {IsUnique = true}));

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}