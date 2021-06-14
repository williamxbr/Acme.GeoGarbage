using System;
using System.Collections.Generic;
using static Acme.GeoGarbage.Dominio.Enums.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RecursosDeColeta
    {
        public int Senha { get; set; }
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public EPerfil Perfil { get; set; }
        public bool Ativo { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual IEnumerable<RecursosDaJornada> RecursosDaJornadas { get; set; }
        
    }
}
