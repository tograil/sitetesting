using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;


namespace IoC
{
    public class DependecyResoloverFactory
    {
        private readonly string _diFilePath;

        private AutofacWebApiDependencyResolver _resolver;

        public IContainer AutofacContainer { get; private set; }
        public ContainerBuilder ContainerBuilder { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public DependecyResoloverFactory(string diFilePath)
        {
            _diFilePath = diFilePath;
            ContainerBuilder = new ContainerBuilder();
        }

        public void RegisterModules(Module module)
        {
            ContainerBuilder.RegisterModule(module);
        }

        /// <summary>
        ///     Configure and create dependency resolver
        /// </summary>
        public void CreateResolver()
        {
            var configReader = new ConfigurationSettingsReader("autofac-dependencies", _diFilePath);
            ContainerBuilder.RegisterModule(configReader);

            AutofacContainer = ContainerBuilder.Build();
            _resolver = new AutofacWebApiDependencyResolver(AutofacContainer);
        }

        /// <summary>
        ///     Get dependency resolver instance
        /// </summary>
        /// <returns></returns>
        public IDependencyResolver GetResolver()
        {
            return _resolver;
        }
    }
}
