using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConsultaDinamicaAssociacaoConfig : EntityTypeConfiguration<ConsultaDinamicaAssociacao>
    {
        public ConsultaDinamicaAssociacaoConfig()
        {
            HasKey(f => f.IdConsultaDinamicaAssociacao);

            Property(f => f.IdConsultaDinamicaAssociacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.ConsultaDinamica)
                .WithMany()
                .HasForeignKey(f => f.IdConsultaDinamica);

            HasRequired(f => f.ConstrutorChaveEstrangeira)
                .WithMany()
                .HasForeignKey(f => f.IdConstrutorChaveEstrangeira);
        }
    }
}