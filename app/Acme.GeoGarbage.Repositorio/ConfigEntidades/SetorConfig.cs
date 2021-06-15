using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class SetorConfig : EntityTypeConfiguration<Setor>
    {
        public SetorConfig()
        {
            HasKey(f => f.IdSetor);

            Property(t => t.IdSetor)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.IdCliente);

        }
    }
}
