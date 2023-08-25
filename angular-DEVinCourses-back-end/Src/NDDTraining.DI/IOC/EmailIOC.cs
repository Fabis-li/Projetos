
using Microsoft.Extensions.DependencyInjection;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Infra.Services;

namespace NDDTraining.DI.IOC
{
    public class EmailIOC
    {
        public static void RegisterServices(IServiceCollection builder)
       {
            builder.AddScoped<IEmailService, EmailService>();
        }
        
    }
}