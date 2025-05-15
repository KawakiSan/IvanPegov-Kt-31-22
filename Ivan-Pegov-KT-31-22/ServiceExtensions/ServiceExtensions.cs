using Ivan_Pegov_KT_31_22.Interfaces.StudentInterfaces;
using NLog.Filters;

namespace Ivan_Pegov_KT_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            return services;
        }
    }
}
