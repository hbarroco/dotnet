using Microsoft.Extensions.DependencyInjection;
using school_route.repository.connection;
using school_route.repository.implementation;
using school_route.repository.interfaces;
using school_route.services.implementation;
using school_route.services.interfaces;

namespace school_route.services
{
    public static class ServicesIoCRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ProviderConnection>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerServices, CustomerServices>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}