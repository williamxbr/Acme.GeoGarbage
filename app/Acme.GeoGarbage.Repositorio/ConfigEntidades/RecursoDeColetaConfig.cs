using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class RecursoDeColetaConfig : EntityTypeConfiguration<RecursoDeColeta>
    {
        public RecursoDeColetaConfig()
        {
            HasKey(f => f.IdRecursoDeColeta);

            Property(f => f.IdRecursoDeColeta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.IdCliente);
        }
    }
}
