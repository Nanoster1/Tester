using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StructsManager.Models
{
    public class AssemblyModel
    {
        public AssemblyModel(Assembly assembly, string? name = null)
        {
            Name = name ?? assembly.GetName().Name;
            Types = assembly.GetTypes().ToList();
        }
        public string Name { get; }
        public List<Type> Types { get; }
    }
}
