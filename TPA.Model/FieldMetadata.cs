using System.ComponentModel.DataAnnotations;

namespace TPA.Model
{
    public class FieldMetadata
    {
        [Key]
        public virtual int Id { get; set; }
    }
}