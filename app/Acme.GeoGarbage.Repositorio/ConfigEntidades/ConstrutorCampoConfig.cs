using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConstrutorCampoConfig : EntityTypeConfiguration<ConstrutorCampo>
    {
        public ConstrutorCampoConfig()
        {
            HasKey(f => f.IdConstrutorCampo);

            Property(f => f.IdConstrutorCampo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(60);

            Property(f => f.Apelido)
                .IsRequired()
                .HasMaxLength(60);

            HasRequired(f => f.ConstrutorTabela)
               .WithMany()
               .HasForeignKey(f => f.IdConstrutorTabela);

        }
    }
}
