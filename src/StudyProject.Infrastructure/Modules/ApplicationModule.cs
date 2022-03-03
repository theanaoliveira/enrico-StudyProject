using Autofac;
using StudyProject.Application.UseCases;
using StudyProject.Application.UseCases.Add;
using StudyProject.Application.UseCases.GetAll;
using StudyProject.Application.UseCases.GetById;

namespace StudyProject.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddUseCase>().As<IAddUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetAllUseCase>().As<IGetAllUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetByIdUseCase>().As<IGetByIdUseCase>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(Handler<>).Assembly).AsImplementedInterfaces().AsSelf().InstancePerDependency();
        }
    }
}
