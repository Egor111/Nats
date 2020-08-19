namespace BasicFunctionality.DataBase.Context
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<SendNats> SendNats { get; set; }
        //public ApplicationDbContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = EGOR-PC\\SQLEXPRESS; Database = SendNats; Trusted_Connection = True; MultipleActiveResultSets=true");
        }
    }
}
