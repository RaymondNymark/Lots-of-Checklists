using Autofac;

namespace Lots_of_Checklists.Core
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ChecklistRepository>().As<IChecklistRepository>();
            builder.RegisterType<ChecklistService>().As<IChecklistService>();
            builder.RegisterType<Lots_of_Checklists.Models.LotsOfChecklistsContext>();

            return builder.Build();
        }
    }
}
