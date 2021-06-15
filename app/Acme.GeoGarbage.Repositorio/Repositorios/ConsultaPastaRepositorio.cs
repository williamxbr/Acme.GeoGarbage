using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class ConsultaPastaRepositorio : RepositorioBase<ConsultaPasta>, IConsultaPastaRepositorio
    {
        public ConsultaPasta BuscaPorPasta(string pasta)
        {
            return Db.ConsultaPastas.FirstOrDefault(p => p.NomePasta == pasta);
        }

        public IEnumerable<ConsultaPasta> BuscaTodosComItens()
        {
            return Db.ConsultaPastas.ToList();
        }
    }
}