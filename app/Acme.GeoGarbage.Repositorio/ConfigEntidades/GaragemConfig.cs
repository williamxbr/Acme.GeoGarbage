using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class GaragemConfig : EntityTypeConfiguration<Garagem>
    {
        public GaragemConfig()
        {
            HasKey(f => f.IdGaragem);

            Property(t => t.IdGaragem)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.IdCliente);

        }
    }
}
