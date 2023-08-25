using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Infra.Data.Repository;
using NDDTraining.Infra.Data.Repository.NDDTraining.Infra.Data.Repository;

namespace NDDTraining.DI.IOC
{
    public static class RepositoryIoc
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection builder)
        {
            return builder
                  .AddDbContext<NDDTrainingDbContext>()
                  .AddScoped<IModuleRepository, ModuleRepository>()
                  .AddScoped<ITrainingRepository, TrainingRepository>()
                  .AddScoped<IRegistrationRepository, RegistrationRepository>()
                  .AddScoped<IUserRepository, UserRepository>()
                  .AddScoped<ICompletedModuleRepository, CompletedModuleRepository>()
                  .AddScoped<ITrainingActivityRepository, TrainingActivityRepository>();
        }
    }
}
