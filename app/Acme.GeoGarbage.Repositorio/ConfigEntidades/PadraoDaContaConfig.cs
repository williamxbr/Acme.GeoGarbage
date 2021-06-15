using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class PadraoDaContaConfig : EntityTypeConfiguration<PadraoDaConta>
    {
        public PadraoDaContaConfig()
        {
            HasKey(f => f.IdUsuario);
        }
    }
}