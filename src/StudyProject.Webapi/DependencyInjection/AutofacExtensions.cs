using Autofac;
using StudyProject.Infrastructure.Modules;

namespace StudyProject.Webapi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();

            return builder;
        }
    }
}
