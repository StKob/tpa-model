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
        public string Name { get; set; }

        public string NamespaceName { get; set; }

        public TypeMetadata BaseType { get; set; }

        public ICollection<TypeMetadata> GenericArguments { get; set; }

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

        public ICollection<AttributeMetadata> Attributes { get; set; }

        public ICollection<TypeMetadata> ImplementedInterfaces { get; set; }
    
        public ICollection<TypeMetadata> NestedTypes { get; set; }

        public TypeMetadata DeclaringType { get; set; }

        public ICollection<PropertyMetadata> TypeProperties { get; set; }

        public ICollection<MethodMetadata> Methods { get; set; }
        public ICollection<MethodMetadata> Constructors { get; set; }
        public ICollection<FieldMetadata> Fields { get; set; }

        public bool IsBuiltIn { get; set; }

        public bool IsGeneric { get; set; }

        [Key]
        public virtual int Id { get; set; }

        [ForeignKey("IsTemplateIn")]
        public virtual int? IsTemplateInId { get; set; }

        [ForeignKey("DeclaringType")]
        public virtual int? DeclaringTypeId { get; set; }

        public virtual TypeMetadata IsTemplateIn { get; set; }

        public virtual AccessLevel? AccessLevel { get; set; }

        public virtual SealedEnum? SealedEnum { get; set; }

        public virtual AbstractEnum? AbstractEnum { get; set; }

        public virtual ICollection<TypeMetadata> TypesImplementingThisInterface { get; set; }

    }
}
