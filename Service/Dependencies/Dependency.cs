using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using Data;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Service.Dependencies
{
    public static class Dependency
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // core layer'daki önemli bağımlılıklar.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddDbContext<Context>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SqlConnection"), opt =>
                {
                    opt.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name);


                });
            });


            // repositorileri otomatik olarak implement eden metot.
            Assembly.GetAssembly(typeof(Context))
                .GetTypes()
                .Where(a => a.Name.EndsWith("Repository") && !a.IsAbstract && !a.IsInterface)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
               .ToList()
               .ForEach(
               typesToRegister =>
               {
                   typesToRegister.serviceTypes.ForEach(typeToRegister =>
                            services.AddScoped(typeToRegister, typesToRegister.assignedType));
               });


            // servisleri otomatik olarak implement eden methot
            Assembly.GetExecutingAssembly()
               .GetTypes()
               .Where(a => a.Name.EndsWith("Service") && !a.IsAbstract && !a.IsInterface)
               .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
               .ToList()
               .ForEach(
               typesToRegister =>
               {
                   typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
               });

        }
    }
}
