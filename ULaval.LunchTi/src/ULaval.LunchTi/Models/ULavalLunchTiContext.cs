using Microsoft.Data.Entity;

namespace ULaval.LunchTi.Models
{
    public class ULavalLunchTiContext : DbContext
    {
        private static bool _created = false;

        public ULavalLunchTiContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<TodoItemModel> TodoItems { get; set; }
    }
}
