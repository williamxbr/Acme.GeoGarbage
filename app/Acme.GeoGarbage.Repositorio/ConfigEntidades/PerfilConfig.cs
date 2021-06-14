using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class PerfilConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfig()
        {
            HasKey(f => f.IdPerfil);

            Property(f => f.IdPerfil)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(f => f.Descricao)
                .HasMaxLength(200);

        }
    }
}