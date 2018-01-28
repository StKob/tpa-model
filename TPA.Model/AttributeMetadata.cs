using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    public class AttributeMetadata
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual ICollection<TypeMetadata> TypesUsingThisAttribute { get; set; }
    }
}
