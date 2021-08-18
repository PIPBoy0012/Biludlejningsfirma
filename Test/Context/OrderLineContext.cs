using System;
using Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Test.Context
{
    public class OrderLineContext : DbContext
    {
        public OrderLineContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<OrderLine> orderLines { get; set; }
    }
}
