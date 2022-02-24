using Autofac;
using StudyProject.Infrastructure.Module;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("StudyProject.Test.ConfigureTests", "StudyProject.Test")]
namespace StudyProject.Test
{
    public class ConfigureTests : AutofacTestFramework
    {
        public ConfigureTests(IMessageSink diagnosticMessageSink) 
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
