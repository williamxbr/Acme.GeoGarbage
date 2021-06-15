using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ClienteAcessoTraffilogConfig : EntityTypeConfiguration<ClienteAcessoTraffilog>
    {
        public ClienteAcessoTraffilogConfig()
        {
            HasKey(t => t.IdCliente);

            Property(t => t.IdCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}