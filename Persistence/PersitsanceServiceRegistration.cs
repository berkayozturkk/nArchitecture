﻿using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class PersitsanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices
        (this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("Test"));
        services.AddScoped<IBrandRepository,BrandRepository>();
        
        return services;
    }   
}
