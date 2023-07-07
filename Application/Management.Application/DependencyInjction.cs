using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Management.Application.Interface;
using Management.Application.Services;
using Management.Core.Interface;
using Management.Infrastructure.Repository.Base;
using Management.Infrastructure.Repository;
using Management.Core.Repository;

namespace Management.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IDbHelper, SqlDataHelper>();
            services.AddTransient<IEmployInfo, EmployDetailsService>();
            services.AddTransient<IAPIRepository, APIRepository>();
            return services;

        }
    }

}
