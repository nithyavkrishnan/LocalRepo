using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomFilter
{
    public interface ITypeFinder
    {
        ///// <summary>
        ///// Gets all SmartStore specific assemblies (core & all plugins)
        ///// </summary>
        ///// <param name="ignoreInactivePlugins">Indicates whether uninstalled plugin's assemblies should be ignored</param>
        ///// <returns>A list of assemblies that should be loaded by the SmartStore factory.</returns>
        IEnumerable<Assembly> GetAssemblies(bool ignoreInactivePlugins = false);
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
    }       
}
