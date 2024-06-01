using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext {
    public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options) {
    }
    public DbSet<User> Users {get; set;}
    public DbSet<Account> Accounts {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Account>().HasKey(x => new {x.UserId, x.Mouth});
    }
}