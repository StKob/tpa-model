using System.ComponentModel.DataAnnotations;

namespace TPA.Model
{
    public class FieldMetadata
    {
        [Key]
        public virtual int Id { get; set; }

        public string Name { get; set; }
        public TypeMetadata Type { get; set; }
        public StaticEnum StaticModifier { get; set; }
        public AccessLevel AccessModifier { get; set; }
    }
}