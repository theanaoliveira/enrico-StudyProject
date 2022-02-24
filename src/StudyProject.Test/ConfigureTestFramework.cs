using Autofac;
using StudyProject.Infrastructure.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("StudyProject.Test.ConfigureTestFramework", "StudyProject.Test")]
namespace StudyProject.Test
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
          : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();
        }
    }
}
