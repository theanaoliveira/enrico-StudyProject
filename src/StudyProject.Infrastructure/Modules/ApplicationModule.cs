using Autofac;
using StudyProject.Application.Repositories;
using StudyProject.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().AsImplementedInterfaces();
        }
    }
}
