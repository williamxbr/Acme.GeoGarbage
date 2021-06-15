using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class SelecaoDeNovoSetorConfig : EntityTypeConfiguration<SelecaoDeNovoSetor>
    {
        public SelecaoDeNovoSetorConfig()
        {
            HasKey(t => t.IdSelecaoDeNovoSetor);

            Property(t => t.IdSelecaoDeNovoSetor)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Jornada)
                .WithMany()
                .HasForeignKey(t => t.IdJornada);
        }
    }
}
