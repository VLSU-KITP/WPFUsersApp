using Microsoft.EntityFrameworkCore;

namespace UsersApp
{
    class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\Desktop\UsersApp\Users.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
