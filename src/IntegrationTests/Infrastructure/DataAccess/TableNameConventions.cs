using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess
{
    public class TableNameConventions : IClassConvention {
        public void Apply(IClassInstance instance) {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}