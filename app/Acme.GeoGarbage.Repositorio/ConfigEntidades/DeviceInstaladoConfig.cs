using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class DeviceInstaladoConfig : EntityTypeConfiguration<DeviceInstalado>
    {
        public DeviceInstaladoConfig()
        {
            HasKey(t => t.IdInstalacao);
            Property(t => t.IdInstalacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Device)
                .WithMany()
                .HasForeignKey(t => t.IdDevice);

            HasRequired(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.IdUsuario);

            HasRequired(t => t.Veiculo)
                .WithMany()
                .HasForeignKey(t => t.IdVeiculo);

        }
    }
}
