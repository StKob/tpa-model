using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace TPA.Model
{
    [JsonObject(IsReference = true)]
    public class NamespaceMetadata
    {
        [Key]
        public virtual int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TypeMetadata> Types { get; set; }





        public NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            var tmp = types;

            Name = name;

            var help = from Type type in types
                       select TypeMetadata.EmitReference(type);

            Collection<TypeMetadata> col = new Collection<TypeMetadata>();

            foreach (var item in help)
            {
                col.Add(item);
            }

            Types = col;
        }

        public NamespaceMetadata()
        {

        }
    }
}
