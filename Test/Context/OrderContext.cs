using System;
using Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Test.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
