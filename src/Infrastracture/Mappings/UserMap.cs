using FluentNHibernate.Mapping;

namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess
{
    public class UserMap : ClassMap<User> {
        public UserMap() {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Role);
        }
    }
}