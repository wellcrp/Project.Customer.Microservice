using Autofac;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project.Customer.Application.Handlers.QueryHandler;
using Project.Customer.Application.Mapper;
using Project.Customer.Domain.Persistence.Interface;
using Project.Customer.Infra.Persistence.Repositories.UnitOfWork;
using Project.Customer.Infra.Repository.Repositories.Query.Repositories;
using Project.Customer.Infra.Repository.Repositories.Repository;
using System.Reflection;

namespace Project.Customer.Infra.IOC.InjectionContainer
{
    public static class DependencyContainer
    {
        public static void RegisterApplicationService(this IServiceCollection service)
        {
            var builder = new ContainerBuilder();

            #region SERVICE AUTOMAPPER
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            #endregion

            #region SERVIÇOS            
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.RegisterType<GetAllCustomerHandler>().As<IPersistenceUnitOfWork>();
            #endregion

            #region CAMADA REPOSITORIO SQL
            service.AddSingleton(mapper);
            service.AddTransient(typeof(IRepositoryGenericAsync<>), typeof(RepositoryGenericAsync<>));
            service.AddScoped<IPersistenceUnitOfWork, PersistenceUnitOfWork>();
            service.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            //service.AddTransient<ICustomerRepository, CustomerInfraestructureRepository>();
            #endregion            
        }
    }
}
