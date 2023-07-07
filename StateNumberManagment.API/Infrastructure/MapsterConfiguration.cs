using Mapster;
using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagment.API.Infrastructure
{
    public static class MapsterConfiguration
    {
        public static void AddMapping(this IServiceCollection service)
        {
            TypeAdapterConfig<StateNumberRequestModel, StateNumber>.NewConfig();
        }
    }
}
