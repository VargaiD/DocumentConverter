using Autofac;
using NotinoTest.Business.FileTools;
using NotinoTest.Business.Parsing;
using NotinoTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Business
{
    public static class DependencyHelper
    {
        public static IContainer Container { get; set; }
        public static IContainer InitialiazeContainer()
        {
        var builder = new ContainerBuilder();

            builder.RegisterType<JsonParsingService>().InstancePerLifetimeScope().Named<IParsingService>(".json");
            builder.RegisterType<XmlParsingService>().InstancePerLifetimeScope().Named<IParsingService>(".xml");

            builder.RegisterType<FileSystemAccessor>().InstancePerLifetimeScope().Named<IFileAccessor>("-f");

            return builder.Build();
        }
    }
}
