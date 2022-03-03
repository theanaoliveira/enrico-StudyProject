using Autofac;
using AutoMapper;
using StudyProject.Application.Repositories;
using StudyProject.Infrastructure.Mapper;
using StudyProject.Infrastructure.Repositorios;
using System.Collections.Generic;

namespace StudyProject.Infrastructure.Module
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().AsImplementedInterfaces().AsSelf();

            Mapper(builder);
        }

        private void Mapper(ContainerBuilder builder)
        {
            builder.RegisterType<MapperProfile>().As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
