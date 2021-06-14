using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Acme.GeoGarbage.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class DeviceConfig : EntityTypeConfiguration<Device>
    {
        public DeviceConfig()
        {
            HasKey(t => t.IdDevice);

            Property(t => t.IdDevice)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.ChaveDevice)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("UQ_Devices_ChaveDevice") {IsUnique = true}));

        }
    }
}
