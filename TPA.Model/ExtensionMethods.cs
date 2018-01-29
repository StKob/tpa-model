using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    static class ExtensionMethods
    {
        internal static bool IsVisible(this Type type)
        {
            return type.IsPublic || type.IsNestedPublic || type.IsNestedFamily || type.IsNestedFamANDAssem;
        }

        internal static bool IsVisible(this MethodBase method)
        {
            return method != null && (method.IsPublic || method.IsFamily || method.IsFamilyAndAssembly);
        }

        internal static string GetNamespace(this Type type)
        {
            string nmSpace = type.Namespace;

            if (nmSpace != null) return nmSpace;
            else return String.Empty;

        }

        internal static bool IsBuiltIn(this Type type)
        {
            return type.Namespace == "System";
        }
    }
}
