using Autofac;
using StudyProject.Application.UseCases;
using StudyProject.Application.UseCases.Add;

namespace StudyProject.Infrastructure.Module
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddUseCase>().As<IAddUseCase>().AsImplementedInterfaces().AsSelf();
            
            builder.RegisterAssemblyTypes(typeof(Handler<>).Assembly).AsImplementedInterfaces().AsSelf().InstancePerDependency();
        }
    }
}
