using bModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace bBehavior.DataBase
{
    public class AppDB: DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Human> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public AppDB() => Database.EnsureCreated();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Baaank.db");
        }
    }
}
