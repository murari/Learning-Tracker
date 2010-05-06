using System.Linq;
using NUnit.Framework;

namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess {
    [TestFixture]
    public class RepositoryTests {
        [Test]

        public void should_be_able_to_get_all_users() {
            var repository = new Repository(NHhelper.GetSessionFactory);
            var users = repository.GetAll<User>();
         Assert.That(users.Count(), Is.GreaterThan(0));

        }

        [Test]

        public void should_be_able_to_insert_a_users() {
            var repository = new Repository(NHhelper.GetSessionFactory);
            var user = new User { Name = "TestUser", Email = "testuser@cosmicvent.com", Password = "testpassword", Role = 2 };
            repository.Save(user);
            var user1 = repository.Get<User>(user.Id);
            Assert.AreEqual("TestUser", user1.Name);
        }
    }
}