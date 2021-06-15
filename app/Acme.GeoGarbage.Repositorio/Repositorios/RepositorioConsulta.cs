using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Repositorio.Contexto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class RepositorioConsulta : IDisposable, IRepositorioConsulta
    {
        protected GeoGarbageContext Db = new GeoGarbageContext();

        public void Dispose()
        {
            Db.Dispose();
        }

        public dynamic Lista(Type resultType, string SQL)
        {
            return Db.Database.SqlQuery(resultType, SQL);
        }
    }
}
