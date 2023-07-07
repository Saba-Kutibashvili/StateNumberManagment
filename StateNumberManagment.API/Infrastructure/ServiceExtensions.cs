using StateNumberManagement.Application;
using StateNumberManagement.Application.Orders;
using StateNumberManagement.Application.StateNumberReservations;
using StateNumberManagement.Application.StateNumbers;
using StateNumberManagement.Infrastructure;
using StateNumberManagement.Infrastructure.Orders;
using StateNumberManagement.Infrastructure.Reservations;
using StateNumberManagement.Infrastructure.StateNumbers;

namespace StateNumberManagment.API.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStateNumberService, StateNumberService>();
            services.AddScoped<IStateNumberRepository, StateNumberRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
