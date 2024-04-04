using school_route.infrastructure;
using school_route.services;

namespace school_route.api.Utils
{
    public static class IoCRegistration
    {
        public static void AddInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutoMapperProfileRegistration));
            InfraIoCRegistration.AddServiceInfrastructure(builder);
            ServicesIoCRegistration.AddServiceInfrastructure(builder.Services);
        }
    }
}
