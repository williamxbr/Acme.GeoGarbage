using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConsultaDinamicaCondicaoConfig : EntityTypeConfiguration<ConsultaDinamicaCondicao>
    {
        public ConsultaDinamicaCondicaoConfig()
        {
            HasKey(f => f.IdConsultaDinamicaCondicao);

            Property(f => f.IdConsultaDinamicaCondicao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.ConstrutorCampo)
                .WithMany()
                .HasForeignKey(f => f.IdConstrutorCampo);

            HasRequired(f => f.ConsultaDinamica)
                .WithMany()
                .HasForeignKey(f => f.IdConsultaDinamica);
        }

    }
}