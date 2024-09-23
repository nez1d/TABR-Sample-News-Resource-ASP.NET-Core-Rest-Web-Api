using System.Reflection;

namespace Tabr.Application.Common.Mappers
{
    public class AssemblyMappingsProfile
    {
        public AssemblyMappingsProfile(Assembly assembly) => 
            ApplyMappingFromAssembly(assembly);

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && 
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("IMapWith");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}