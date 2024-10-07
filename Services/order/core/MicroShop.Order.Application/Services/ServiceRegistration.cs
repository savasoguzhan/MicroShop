using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Order.Application.Services
{
    public static class ServiceRegistration
    {

        public static void AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ServiceCollection).Assembly));
        }
    }
}
