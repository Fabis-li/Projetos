using Microsoft.Extensions.DependencyInjection;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Services;

namespace NDDTraining.DI.IOC
{
    public static class ServiceIoc
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IModuleService, ModuleService>()
                .AddScoped<ITrainingService, TrainingService>()
                .AddScoped<IRegistrationService, RegistrationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICompletedModuleService, CompletedModuleService>()
                .AddScoped<ITrainingActivityService, TrainingActivityService>();
        }
    }
}
