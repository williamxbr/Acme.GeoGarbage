using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class RecursoDaJornadaConfig : EntityTypeConfiguration<RecursoDaJornada>
    {
        public RecursoDaJornadaConfig()
        {
            HasKey(t => t.IdRecursoDaJornada);

            Property(t => t.IdRecursoDaJornada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Jornada)
                .WithMany()
                .HasForeignKey(t => t.IdJornada);
        }
    }
}
