using System.Collections.Generic;
using JPBetley.Foundry.Exceptions;
using System;
using System.Linq;
using System.Reflection;

namespace JPBetley.Foundry
{
    class Crucible
    {
        private readonly IEnumerable<Type> types;
        public Crucible()
        {
            var assemblies = GetDependentAssemblies(Assembly.GetExecutingAssembly());
            this.types = assemblies.SelectMany(a => a.GetTypes());
        }

        internal CastingMold<T> FindCastingMold<T>()
        {
            var typesApplicable = types.Where(type =>
                        type.IsClass &&
                        !type.IsAbstract &&
                        type.BaseType == typeof(CastingMold<T>));

            var count = typesApplicable.Count();
            if (count == 0)
            {
                throw new CastingMoldNotFoundException();
            }

            if (count > 1)
            {
                throw new MultipleCastingMoldsDefinedException();
            }

            return Activator.CreateInstance(typesApplicable.First()) as CastingMold<T>;
        }

        private IEnumerable<Assembly> GetDependentAssemblies(Assembly analyzedAssembly)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => GetNamesOfAssembliesReferencedBy(a)
                                    .Contains(analyzedAssembly.FullName));
        }

        private IEnumerable<string> GetNamesOfAssembliesReferencedBy(Assembly assembly)
        {
            return assembly.GetReferencedAssemblies()
                .Select(assemblyName => assemblyName.FullName);
        }
    }
}
