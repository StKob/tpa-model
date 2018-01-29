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
        public string Name { get; set; }
        public TypeMetadata AttributeType { get; set; }
        public virtual ICollection<TypeMetadata> TypesUsingThisAttribute { get; set; }
        public virtual ICollection<MethodMetadata> MethodsUsingThisAttribute { get; set; }

        public AttributeMetadata()
        {

        }

        public AttributeMetadata(Attribute attr)
        {
            this.AttributeType = TypeMetadata.EmitReference(attr.GetType());
        }
    }
}
