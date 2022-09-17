using Autofac;

namespace users.Infra.CrossCutting.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            DependencyInjection.Load(builder);
        }
    }
}
