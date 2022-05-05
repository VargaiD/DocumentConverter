using Autofac;
using DocumentConverter.Business.Modules;
using DocumentConverter.Business.Parsing;
using DocumentConverter.Business.Services;
using DocumentConverter.Data.Accessors;
using DocumentConverter.Data.Models;
using DocumentConverter.Shared.Helpers;

namespace DocumentConverter.API.Helpers
{
    public static class DependencyHelper
    {
        private static IContainer? _container;

        // Could be made thread safe with locks
        public static IContainer Container { get {
            if (_container == null)
                {
                    _container = InitialiazeContainer();
                }
            return _container;
            } }
        private static IContainer InitialiazeContainer()
        {
        var builder = new ContainerBuilder();

            builder.RegisterType<JsonParsingService>().InstancePerLifetimeScope().Named<IParsingService>(Constants.ParserTypes.JSON);
            builder.RegisterType<XmlParsingService>().InstancePerLifetimeScope().Named<IParsingService>(Constants.ParserTypes.XML);

            builder.RegisterType<FileSystemAccessor>().InstancePerLifetimeScope().Named<IFileAccessor>(Constants.FileStorageTypes.File);
            builder.RegisterType<FileLocationDescriptor>().InstancePerDependency().Named<IFileLocationDescriptor>(Constants.FileStorageTypes.File).WithParameter(new TypedParameter(typeof(string), "locationDescriptor"));

            builder.RegisterType<WebAccessor>().InstancePerLifetimeScope().Named<IFileAccessor>(Constants.FileStorageTypes.Url);
            builder.RegisterType<UrlLocationDescriptor>().InstancePerDependency().Named<IFileLocationDescriptor>(Constants.FileStorageTypes.Url).WithParameter(new TypedParameter(typeof(string), "locationDescriptor"));

            builder.RegisterType<SimpleDocumentModule>().InstancePerLifetimeScope().As<IDocumentModule>();

            return builder.Build();
        }
    }
}
