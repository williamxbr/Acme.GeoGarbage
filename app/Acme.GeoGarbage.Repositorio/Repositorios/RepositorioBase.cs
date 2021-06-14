using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Repositorio.Contexto;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected ProjetoAmbientalContext Db = new ProjetoAmbientalContext();

        public void Adiciona(TEntity entidade)
        {
            Db.Set<TEntity>().Add(entidade);
            Db.SaveChanges();
        }

        public void Atualiza(TEntity entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public TEntity BuscaId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> BuscaTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entidade)
        {
            Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }
    }
}