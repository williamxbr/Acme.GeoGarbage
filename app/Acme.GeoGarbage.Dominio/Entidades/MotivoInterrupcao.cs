using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class MotivoInterrupcao
    {
        [PrimaryKey]
        public Guid IdMotivoInterrupcao { get; set; }
        public string Motivo { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual IEnumerable<Interrupcao> Interrupcoes { get; set; }
    }
}
