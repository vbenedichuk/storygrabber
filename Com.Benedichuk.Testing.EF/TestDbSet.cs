using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Com.Benedichuk.Testing.EF
{
    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
          where TEntity : class
    {
        List<TEntity> itemsToRemove;
        ObservableCollection<TEntity> data;
        IQueryable query;

        public TestDbSet()
        {
            data = new ObservableCollection<TEntity>();
            query = data.AsQueryable();
            itemsToRemove = new List<TEntity>();
        }

        public override TEntity Add(TEntity item)
        {
            data.Add(item);
            return item;
        }

        public override TEntity Remove(TEntity item)
        {
            data.Remove(item);
            return item;
        }

        public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            itemsToRemove.AddRange(entities);
            return entities;
        }        

        public override TEntity Attach(TEntity item)
        {
            data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return data; }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<TEntity>(query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<TEntity>(data.GetEnumerator());
        }

        public virtual void SaveChanges() {
            foreach(TEntity entity in itemsToRemove)
            {
                data.Remove(entity);
            }
            itemsToRemove.Clear();
        }
    }
}
