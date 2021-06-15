using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class UsuarioDeClienteConfig : EntityTypeConfiguration<UsuarioDeCliente>
    {
        public UsuarioDeClienteConfig()
        {
            HasKey(t => t.IdUsuarioDeCliente);

            Property(t => t.IdUsuarioDeCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Cliente)
                .WithMany()
                .HasForeignKey(t => t.IdCliente);

            HasRequired(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.IdUsuario);

        }
    }
}