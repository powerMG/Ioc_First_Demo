using Core.Contract;
using Core.Contract.Channel;
using Core.Service;
using Core.Service.Channel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class MapperRegistor
    {
       public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAdministrator, AdministratorService>();
            service.AddScoped<IChannelContract, ChannelService>();
        }
    }
}
