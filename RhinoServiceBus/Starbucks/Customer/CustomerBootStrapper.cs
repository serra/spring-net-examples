using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;
using Rhino.ServiceBus.Spring;

namespace Starbucks.Customer
{
    public class CustomerBootStrapper : SpringBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //
            // IMO we do not need to register a saga persister, 
            // because the customer isn't controlled by a saga, 
            // but by a UI controller.
            //

            // Original Castle equivalent
            //Container.Register(
            //    Component.For(typeof(ISagaPersister<>))
            //        .ImplementedBy(typeof(InMemorySagaPersister<>))
            //    );
        }

        protected override bool IsTypeAcceptableForThisBootStrapper(System.Type t)
        {
            return t.Namespace == "Starbucks.Customer";
        }
    }
}
