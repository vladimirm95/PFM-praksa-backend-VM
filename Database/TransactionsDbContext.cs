using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Transactions.Database.Entities;

namespace Transactions.Database{

    public class TransactionsDbContext : DbContext {
        public DbSet <TransactionEntity> transactions { get; set;}

        public TransactionsDbContext(DbContextOptions options) : base (options){

        }

        // protected override void OnModelCreating (ModelBuilder modelBuilder){
        //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // }



}

}

