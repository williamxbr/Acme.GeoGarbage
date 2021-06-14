using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RecursosDaJornada
    {
        public Guid IdJornada { get; set; }
        public Guid IdRecursoDeColeta { get; set; }
        public DateTime DataHoraAlocacao { get; set; }
        public virtual RecursosDeColeta RecursosDeColeta { get; set; }
        public virtual Jornada Jornada { get; set; }

    }
}
