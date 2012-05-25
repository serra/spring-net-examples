using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;
using Rhino.ServiceBus.Serializers;
using Rhino.ServiceBus.Spring;

namespace Starbucks.Cashier
{
    public class CashierBootStrapper : SpringBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //
            // IMO we do not need to register a saga persister, 
            // because the CashierSaga isn't a stateful saga.
            //
            // Original Castle equivalent:
            //Container.Register(
            //                Component.For(typeof(ISagaPersister<>))
            //                    .ImplementedBy(typeof(InMemorySagaPersister<>))
            //                );
        }

        protected override bool IsTypeAcceptableForThisBootStrapper(System.Type t)
        {
            return t.Namespace == "Starbucks.Cashier";
        }
    }
}
