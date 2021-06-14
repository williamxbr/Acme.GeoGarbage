using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class DescargaAterroConfig : EntityTypeConfiguration<DescargaAterro>
    {
        public DescargaAterroConfig()
        {
            HasKey(t => t.IdDescargaAterro);

            Property(t => t.IdDescargaAterro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
