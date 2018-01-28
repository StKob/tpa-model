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

        [ForeignKey("IsTemplateIn")]
        public int? IsTemplateInId { get; set; }

        public TypeMetadata IsTemplateIn { get; set; }

        public string Name { get; set; }

        public string NamespaceName { get; set; }

        public TypeMetadata BaseType { get; set; }

        public ICollection<TypeMetadata> GenericArguments { get; set; }

        public AccessLevel? AccessLevel { get; set; }

        public SealedEnum? SealedEnum { get; set; }

        public AbstractEnum? AbstractEnum { get; set; }

        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers
        {
            get
            {
                return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(AccessLevel.Value, SealedEnum.Value, AbstractEnum.Value);
            }
            set
            {
                AccessLevel = value.Item1;
                SealedEnum = value.Item2;
                AbstractEnum = value.Item3;
            }
        }

        public TypeKind? KindOfType { get; set; }






    }
}
