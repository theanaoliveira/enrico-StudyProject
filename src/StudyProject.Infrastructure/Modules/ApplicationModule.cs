using Autofac;
using AutoMapper;
using StudyProject.Application.Repositories;
using StudyProject.Application.UseCases.Add;
using StudyProject.Application.UseCases.GetAll;
using StudyProject.Application.UseCases.GetById;
using StudyProject.Infrastructure.Mapper;
using StudyProject.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<addUseCase>().As<IAddUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetAllUseCase>().As<IGetAllUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetByIdUseCase>().As<IGetByIdUseCase>().AsImplementedInterfaces();
            
        }

       
    }
}
