using school_route.services;

namespace school_route.api.Utils
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            ServicesIoCRegistration.AddServiceInfrastructure(services);
        }
    }
}
