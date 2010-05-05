using System.IO;
using FluentNHibernate.Cfg;
using LearningTracker.IntegrationTests.Infrastructure.DataAccess;
using NHibernate;
using NHibernate.Cfg;

namespace LearningTracker.IntegrationTests {
    public static class NHhelper {
        private static ISessionFactory _sessionFactory;
        private static readonly object _lockObject = new object();

        public static ISessionFactory GetSessionFactory {
            get {
                if (_sessionFactory == null) {
                    lock (_lockObject) {
                        string mappingDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "mapping_docs");
                        Directory.CreateDirectory(mappingDirectoryPath);

                        Configuration nhibConfiguration = new Configuration().Configure();

                        _sessionFactory = Fluently.Configure(nhibConfiguration)
                           .Mappings(x => x.FluentMappings
                                              .AddFromAssemblyOf<Repository>()
                                              .ExportTo(mappingDirectoryPath)
                                              .Conventions.AddFromAssemblyOf<TableNameConventions>())
                           .BuildSessionFactory();
                    }
                }
                return _sessionFactory;
            }
        }
    }
}