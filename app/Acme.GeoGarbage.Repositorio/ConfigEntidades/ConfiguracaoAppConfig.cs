using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConfiguracaoAppConfig : EntityTypeConfiguration<ConfiguracaoApp>
    {
        public ConfiguracaoAppConfig()
        {
            HasKey(t => t.IdConfiguracaoApp);

            Property(t => t.IdConfiguracaoApp)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Clientes)
               .WithMany()
               .HasForeignKey(p => p.IdCliente);

        }
    }
}
