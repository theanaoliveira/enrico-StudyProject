using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyProject.Application.Repositories;
using StudyProject.Infrastructure.Mapper;
using StudyProject.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;

namespace StudyProject.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().AsImplementedInterfaces().AsSelf();

            Mapper(builder);
            Database(builder);
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

        private void Database(ContainerBuilder builder)
        {
            var conn = Environment.GetEnvironmentVariable("CONN");

            builder.RegisterAssemblyTypes(typeof(Context).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(conn))
            {
                var context = new Context();
                context.Database.Migrate();
            }
        }
    }
}
