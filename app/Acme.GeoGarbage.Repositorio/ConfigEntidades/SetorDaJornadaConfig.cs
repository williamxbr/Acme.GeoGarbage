using System.ComponentModel.DataAnnotations.Schema;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class SetorDaJornadaConfig : EntityTypeConfiguration<SetorDaJornada>
    {
        public SetorDaJornadaConfig()
        {
            HasKey(t => t.IdSetorDaJornada);

            Property(t => t.IdSetorDaJornada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Jornada)
                .WithMany()
                .HasForeignKey(t => t.IdJornada);

            HasRequired(t => t.Setor)
                .WithMany()
                .HasForeignKey(t => t.IdSetor);

            Property(t => t.TempoSetorDaJornada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalHorimetro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(t => t.TotalOdometro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

        }
    }
}
