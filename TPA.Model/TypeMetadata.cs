using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    public class TypeMetadata
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string NamespaceName { get; set; }

        public TypeMetadata BaseType { get; set; }

        public ICollection<TypeMetadata> GenericArguments { get; set; }

        [ForeignKey("IsTemplateIn")]
        public int? IsTemplateInId { get; set; }

        public TypeMetadata IsTemplateIn { get; set; }



    }
}
