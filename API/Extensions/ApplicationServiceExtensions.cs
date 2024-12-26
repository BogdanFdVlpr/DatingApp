using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddAplicationServises(this IServiceCollection services, IConfiguration config)
  {
    services.AddControllers();
    services.AddDbContext<DataContext>(opt =>
    {
      opt.UseSqlite(config.GetConnectionString("DefaultConnetion"));
    });

    services.AddCors();
    services.AddScoped<ITokenServices, TokenService>();

    return services;
  }
}
