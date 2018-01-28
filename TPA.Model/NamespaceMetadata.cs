using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    public class NamespaceMetadata
    {
        [Key]
        public virtual int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TypeMetadata> Types { get; set; }

    }
}
