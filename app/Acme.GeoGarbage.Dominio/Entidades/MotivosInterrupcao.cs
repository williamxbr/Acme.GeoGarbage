using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class MotivosInterrupcao
    {
        public Guid IdMotivoInterrupcao { get; set; }
        public string Motivo { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<Interrupcao> Interrupcoes { get; set; }
    }
}
