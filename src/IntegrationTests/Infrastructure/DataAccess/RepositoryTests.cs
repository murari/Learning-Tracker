using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NUnit.Framework;

namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess {
    [TestFixture]
    public class RepositoryTests {
        [Test]

        public void should_be_able_to_get_all_users() {
            var repository = new Repository(NHhelper.GetSessionFactory);
            var users = repository.GetAll<User>();
            //  Assert.IsNotNull(users);
            Assert.That(users.Count(), Is.GreaterThan(0));

        }
    }

    public class User {
        public  virtual long Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public int Role { get; set; }
    }

    public class Repository {
        private readonly ISessionFactory _sessionFactory;


        public Repository(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<T> GetAll<T>()
        {
            List<T> list = _sessionFactory.OpenSession().Linq<T>().ToList();
            return list;
        }
    }

    internal class UserMap : ClassMap<User> {
        public UserMap() {
            Id(x => x.Id);
        }
    }
}