using Application.Interfaces;
using Application.Services;
using Autofac;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services.Services;
using Infrastructure.CrossCutting.Adapter.Interfaces;
using Infrastructure.CrossCutting.Adapter.Map;
using Infrastructure.Repository.Repositories;

namespace Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceProduct>().As<IServiceProduct>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperProduct>().As<IMapperProduct>();
            #endregion

            #endregion

        }
    }
}
