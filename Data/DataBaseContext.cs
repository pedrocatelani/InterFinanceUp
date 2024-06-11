using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Charts;

public class DataBaseContext : DbContext {
    public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options) {
    }
    public DbSet<User> Users {get; set;}
    public DbSet<Account> Accounts {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Account>().HasKey(x => new {x.UserId, x.Month});
    }
}