using System;
using Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Test.Context
{
    public class ProdukterContext : DbContext
    {
        public ProdukterContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Produkter> Produkter { get; set; }
    }
}
