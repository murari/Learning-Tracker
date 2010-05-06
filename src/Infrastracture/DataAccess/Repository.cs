using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess {
    public class Repository {
        private readonly ISessionFactory _sessionFactory;


        public Repository(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<T> GetAll<T>() {
            List<T> list = _sessionFactory.OpenSession().Linq<T>().ToList();
            return list;
        }

        public void Save<T>(T entity) {
            _sessionFactory.OpenSession().Save(entity);
        }

        public T Get<T>(long id) {
            return _sessionFactory.OpenSession().Get<T>(id);
        }
    }
}