using Acme.GeoGarbage.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class ConstrutorChaveEstrangeiraConfig : EntityTypeConfiguration<ConstrutorChaveEstrangeira>
    {
        public ConstrutorChaveEstrangeiraConfig()
        {
            HasKey(f => f.IdConstrutorChaveEstrangeira);

            Property(f => f.IdConstrutorChaveEstrangeira)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(f => f.ConstrutorTabela)
               .WithMany()
               .HasForeignKey(f => f.IdConstrutorTabela);

            HasRequired(f => f.ConstrutorCampo)
               .WithMany()
               .HasForeignKey(f => f.IdConstrutorCampo);

            HasRequired(f => f.ConstrutorTabelaMestre)
               .WithMany()
               .HasForeignKey(f => f.IdConstrutorTabelaMestre);

            HasRequired(f => f.ConstrutorCampoMestre)
               .WithMany()
               .HasForeignKey(f => f.IdConstrutorCampoMestre);
        }
    }
}
