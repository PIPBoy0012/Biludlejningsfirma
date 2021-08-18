using System;
using System.Collections.Generic;

namespace Test.Model.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(long id);

        void Add(TEntity entity);

        void Update(TEntity entityToUpdate, TEntity entity);

        void Delete(TEntity entity);
    }
}
