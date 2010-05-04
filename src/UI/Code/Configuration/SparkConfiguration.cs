using System.Web.Mvc;
using LearningTracker.UI.Code.Controllers;
using Spark;
using Spark.Web.Mvc;

namespace LearningTracker.UI.Code.Configuration {
    public static class SparkConfiguration {
        public static void Configure(ViewEngineCollection engines) {
            //engines.Clear();
            var settings = new SparkSettings
                               {
                                   AutomaticEncoding = true,
                                   Debug = true,
                               };

            settings
                .AddAssembly(typeof(LearningTrackerMvcApplication).Assembly.GetName().Name)
                .AddAssembly(typeof(Controller).Assembly.GetName().Name)
                .SetPageBaseType("ApplicationViewPage");
            var viewFactory = new SparkViewFactory(settings);
            PrecompileViews(viewFactory);
            engines.Add(viewFactory);
        }

        private static void PrecompileViews(SparkViewFactory viewFactory) {
            var batch = new SparkBatchDescriptor();
            batch
                .For<HomeController>();
            viewFactory.Precompile(batch);
        }
    }
}