public class DbSet
{
    private const string DbName = "EF2";
    private const string ConnectionString = $"Data Source=localhost;Initial Catalog={DbName};User ID=sa;Password=Chr!st0pher;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DbSet<Product> Products { get; set; }
    public DbSet<PC> PCs { get; set; }
    public DbSet<Laptop> Laptops { get; set; }
    public DbSet<Printer> Printers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);
        //recheck connectionString if issue connecting to db
  		//can reuse connection string from week 3 using your new database
}