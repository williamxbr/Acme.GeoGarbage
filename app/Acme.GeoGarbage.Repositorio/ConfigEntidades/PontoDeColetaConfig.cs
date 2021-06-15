using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class PontoDeColetaConfig : EntityTypeConfiguration<PontoDeColeta>
    {
        public PontoDeColetaConfig()
        {
            HasKey(f => f.IdPontoDeColeta);
            Property(f => f.IdPontoDeColeta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(f => f.Setor)
                .WithMany()
                .HasForeignKey(f => f.IdSetor);
        }
    }
}