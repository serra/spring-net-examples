using System.Linq;
using System.Reflection;
using NHibernate.Mapping.ByCode;
using Spring.Data.NHibernate;

namespace NHibernateMapByCode
{
    public class ConformistLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        public ConformistLocalSessionFactoryObject()
        {
            ConformistMappingAssemblies = new string[] {};
        }

        public string[] ConformistMappingAssemblies { get; set; }

        protected override void PostProcessConfiguration(NHibernate.Cfg.Configuration config)
        {
            base.PostProcessConfiguration(config);

            // add any conformist mappings in the listed assemblies:
            var mapper = new ModelMapper();

            foreach (var asm in ConformistMappingAssemblies.Select(Assembly.Load))
            {
                mapper.AddMappings(asm.GetTypes());
            }
            
            foreach (var mapping in mapper.CompileMappingForEachExplicitlyAddedEntity())
            {
                config.AddMapping(mapping);    
            }
            
        }
    }
}