using Acme.GeoGarbage.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.GeoGarbage.Repositorio.ConfigEntidades
{
    public class TokenConfig : EntityTypeConfiguration<Token>
    {
        public TokenConfig()
        {
            HasKey(c => c.IdToken);

            Property(c => c.IdToken)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
