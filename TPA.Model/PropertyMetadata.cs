using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    public class PropertyMetadata
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Type")]
        public virtual int TypeId { get; set; }
        public TypeMetadata Type { get; set; }
    }
}
