using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Dotnet.Utils.Enum {
    public class EnumProvider : IEnumProvider {
        public IEnumerable<Type> GetEnumTypes() {
            var enums = new List<Type>();

            enums.AddRange(GetJavaScriptEnums());

            return enums;
        }

        private static IEnumerable<Type> GetJavaScriptEnums() {
            return from a in GetReferencingAssemblies()
                   from t in a.GetTypes()
                   from r in t.GetTypeInfo().GetCustomAttributes<JavaScriptEnumAttribute>()
                   where t.GetTypeInfo().BaseType == typeof(System.Enum)
                   select t;
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies() {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies) {
                try {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                } catch (FileNotFoundException) { }
            }
            return assemblies;
        }
    }
}
