using System.Reflection;
using AutoMapper;
using danskeND.Domain.Services;
using danskeND.Domain.Services.Interfaces;
using danskeND.Domain.Utility;
using danskeND.Repository.Repositories.Common;
using danskeND.Repository.Services;
using danskeND.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DbContext = danskeND.Repository.Context.DbContext;

namespace danskeND.Services;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ISortingService,SortingService>();
        serviceCollection.AddScoped(typeof(IFileService<>),typeof(FileService<>));
        serviceCollection.AddScoped<ISortingAlgorithm, SortingAlgorithm>();
    }

    public static void AddRepoServices(this IServiceCollection serviceCollection)
    {
       serviceCollection.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>)); // jei naudociau db
    }

    public static void AddSql(this IServiceCollection serviceCollection, IConfigurationRoot config)
    {
        serviceCollection.AddDbContext<DbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection") ?? string.Empty)); // jei naudociau db
    }

    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        serviceCollection.AddSingleton(mapperConfig.CreateMapper());
    }
}