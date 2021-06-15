using System;
using Acme.GeoGarbage.Dominio.Enums;
using SQLite;
namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RecursoDaJornada
    {
        [PrimaryKey]
        public Guid IdRecursoDaJornada { get; set; }
        public Guid IdJornada { get; set; }
        public int Senha { get; set; }
        public TipoPerfil Perfil { get; set; }
        public DateTime DataHoraAlocacao { get; set; }
        [Ignore]
        public virtual Jornada Jornada { get; set; }

    }
}
