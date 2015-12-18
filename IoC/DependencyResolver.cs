using System;
using System.Web.Http.Dependencies;


namespace IoC
{
    public static class DependencyResolver
    {
        private static readonly object SetLocker = new object();
        private static DependecyResoloverFactory _dependencyResolverFactory;
        private static volatile bool _isInited;
        private static IDependencyResolver _resolver { get; set; }

        public static void ConfigureResolver(DependecyResoloverFactory resolverFactory)
        {
            if (resolverFactory == null)
            {
                throw new NullReferenceException("Resolver factory can't be null");
            }

            if (_isInited)
            {
                throw new InvalidOperationException("DependencyResolver allready configured");
            }

            InitResolverFactory(resolverFactory);
        }

        public static Autofac.IContainer AutofacContainer => _dependencyResolverFactory.AutofacContainer;

        public static IDependencyResolver Resolver => _resolver;

        public static TAbstraction Get<TAbstraction>() where TAbstraction : class
        {
            return (TAbstraction)_resolver.GetService(typeof(TAbstraction));
        }

        /// <summary>
        ///     Initialize resolver factory
        /// </summary>
        /// <param name="resolverFactory"></param>
        private static void InitResolverFactory(DependecyResoloverFactory resolverFactory)
        {
            lock (SetLocker)
            {
                _dependencyResolverFactory = resolverFactory;
                _dependencyResolverFactory.CreateResolver();
                _resolver = _dependencyResolverFactory.GetResolver();
                _isInited = true;
            }
        }
    }
}
