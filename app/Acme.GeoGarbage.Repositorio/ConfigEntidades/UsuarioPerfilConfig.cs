using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class UsuarioPerfilConfig : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilConfig()
        {
            HasKey(t => t.IdUsuarioPerfil);

            Property(t => t.IdUsuarioPerfil)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.IdUsuario);

            HasRequired(t => t.Perfil)
                .WithMany()
                .HasForeignKey(t => t.IdPerfil);

        }
    }
}
