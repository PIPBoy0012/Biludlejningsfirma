using System;
using System.Collections.Generic;

namespace Test.Model.Repository
{
    public interface IProdukterRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(long id);

        IEnumerable<TEntity> GetType(string type);

        void Add(TEntity entity);

        void Update(TEntity entityToUpdate, TEntity entity);

        void Delete(TEntity entity);
    }
}
