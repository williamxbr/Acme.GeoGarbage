using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class DescargaDeColetaConfig : EntityTypeConfiguration<DescargaDeColeta>
    {
        public DescargaDeColetaConfig()
        {
            HasKey(t => t.IdDescargaDeColeta);
            Property(t => t.IdDescargaDeColeta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.SetorDaJornada)
                .WithMany()
                .HasForeignKey(t => t.IdSetorJornada);

            HasRequired(t => t.DescargaAterro)
                .WithMany()
                .HasForeignKey(t => t.IdDescargaAterro);
        }
    }
}
