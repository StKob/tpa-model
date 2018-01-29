using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    [JsonObject(IsReference = true)]
    public class AssemblyMetadata
    {
        [Key]
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NamespaceMetadata> Namespaces { get; set; }






        public AssemblyMetadata()
        {

        }

        public AssemblyMetadata(Assembly assembly)
        {
            Name = assembly.GetName().Name;

            var tmp = assembly.GetTypes();


            var help = from Type type in assembly.GetTypes()
                       group type by type.Namespace into namespaceGroup
                       select new NamespaceMetadata(namespaceGroup.Key, namespaceGroup);

            Collection<NamespaceMetadata> col = new Collection<NamespaceMetadata>();

            foreach (var item in help)
            {
                col.Add(item);
            }

            Namespaces = col;
        }

    }



}

