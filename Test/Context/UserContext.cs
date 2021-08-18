using System;
using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
