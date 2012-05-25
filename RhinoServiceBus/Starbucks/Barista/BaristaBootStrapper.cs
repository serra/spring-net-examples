using Rhino.ServiceBus;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;
using Rhino.ServiceBus.Serializers;
using Rhino.ServiceBus.Spring;

namespace Starbucks.Barista
{
    public class BaristaBootStrapper : SpringBootStrapper
    {
        private IServiceLocator _serviceLocator;

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            _serviceLocator = new SpringServiceLocator(ApplicationContext);
            ApplicationContext.RegisterSingleton(GetSagaPersister);
            
            // Original Castle Equivalent
            //Container.Register(
            //    Component.For(typeof(ISagaPersister<>))
            //        .ImplementedBy(typeof(InMemorySagaPersister<>))
            //    );
        }

        private ISagaPersister<BaristaSaga> GetSagaPersister()
        {
            return new InMemorySagaPersister<BaristaSaga>(_serviceLocator, 
                                                            new SpringReflection(), 
                                                            new XmlMessageSerializer(new SpringReflection(), _serviceLocator));
        }

        protected override bool IsTypeAcceptableForThisBootStrapper(System.Type t)
        {
            return t.Namespace == "Starbucks.Barista";
        }
    }
}
