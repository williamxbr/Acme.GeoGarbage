using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ExecucaoPontoDeColetaConfig : EntityTypeConfiguration<ExecucaoPontoDeColeta>
    {
        public ExecucaoPontoDeColetaConfig()
        {
            HasKey(f => f.IdExecucaoPontoDeColeta);
            Property(f => f.IdExecucaoPontoDeColeta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(f => f.PontoDeColeta)
                .WithMany()
                .HasForeignKey(f => f.IdPontoDeColeta);

            HasRequired(f => f.SetorDaJornada)
                .WithMany()
                .HasForeignKey(f => f.IdSetorDeJornada);
        }
    }
}