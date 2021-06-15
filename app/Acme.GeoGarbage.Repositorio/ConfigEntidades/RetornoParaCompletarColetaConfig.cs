using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class RetornoParaCompletarColetaConfig : EntityTypeConfiguration<RetornoParaCompletarColeta>
    {
        public RetornoParaCompletarColetaConfig()
        {
            HasKey(t => t.IdRetornoParaCompletarColeta);

            Property(t => t.IdRetornoParaCompletarColeta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.SetorDaJornada)
                .WithMany()
                .HasForeignKey(t => t.IdSetorJornada);

        }
    }
}
