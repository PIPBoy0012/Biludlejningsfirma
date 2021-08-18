using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.Model.Repository;

namespace Test.Model.DataManager
{
    public class ProdukterManager : IDataRepository<Produkter>
    {
        readonly bilbixContext _produkterContext;

        public ProdukterManager(bilbixContext produkterContext)
        {
            _produkterContext = produkterContext;
        }

        public IEnumerable<Produkter> GetAll()
        {
            return _produkterContext.Produkters.ToList();
        }

        public Produkter Get(long id)
        {
            return _produkterContext.Produkters.FirstOrDefault(e => e.ProduktId == id);
        }

        public void Add(Produkter produkter)
        {
            _produkterContext.Add(produkter);
            _produkterContext.SaveChanges();
        }

        public void Update(Produkter produkterToUpdate, Produkter produkter)
        {
            produkterToUpdate.ProduktNavn = produkter.ProduktNavn;
            produkterToUpdate.Pris = produkter.Pris;
            produkterToUpdate.Type = produkter.Type;

            _produkterContext.SaveChanges();
        }

        public void Delete(Produkter produkter)
        {
            _produkterContext.Remove(produkter);
            _produkterContext.SaveChanges();
        }
    }
}
