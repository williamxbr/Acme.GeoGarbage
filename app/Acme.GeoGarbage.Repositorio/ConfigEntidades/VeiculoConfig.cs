using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class VeiculoConfig : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoConfig()
        {
            HasKey(t => t.IdVeiculo);

            Property(t => t.IdVeiculo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Clientes)
                .WithMany()
                .HasForeignKey(t => t.IdCliente);
        }
    }
}
