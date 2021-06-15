using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Repositorio.Contexto;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected GeoGarbageContext Db = new GeoGarbageContext();

        public virtual void Adiciona(TEntity entidade)
        {
            Db.Set<TEntity>().Add(entidade);
            Db.SaveChanges();
        }

        public virtual void Atualiza(TEntity entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual TEntity BuscaId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity BuscaId(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> BuscaTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Pesquisar(Func<TEntity, bool> lambda)
        {
            return Db.Set<TEntity>().Where(lambda);
        }

        public virtual IQueryable<TEntity> Consultar()
        {
            return Db.Set<TEntity>().AsQueryable();
        }

        //public virtual IEnumerable<TEntity> ListaSQL(string SQL)
        //{
        //    return Db.Set<TEntity>().SqlQuery(SQL);
        //}

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual void Remove(TEntity entidade)
        {
            Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }

        public TEntity BuscaId(long id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void AdicionaEmLote(List<TEntity> listaEntidade)
        {
                Db.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entidade in listaEntidade)
                {
                    Db.Set<TEntity>().Add(entidade);
                }
                Db.SaveChanges();
                Db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}