using Microsoft.EntityFrameworkCore;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumberOrders;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Persistance.Context
{
    public class StateNumberManagementContext : DbContext
    {
        public StateNumberManagementContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StateNumber> StateNumbers { get; set; }
        public DbSet<StateNumberOrder> Orders { get; set; }
        public DbSet<StateNumberReservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }
    }
}
