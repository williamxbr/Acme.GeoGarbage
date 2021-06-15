using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConsultaDinaminaTabelaConfig : EntityTypeConfiguration<ConsultaDinamicaTabela>
    {
        public ConsultaDinaminaTabelaConfig()
        {
            HasKey(f => f.IdConsultaDinamicaTabela);

            Property(f => f.IdConsultaDinamicaTabela)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.ConsultaDinamica)
                .WithMany()
                .HasForeignKey(f => f.IdConsultaDinamica);

            HasRequired(f => f.ConstrutorTabela)
                .WithMany()
                .HasForeignKey(f => f.IdConstrutorTabela);
        }
    }
}