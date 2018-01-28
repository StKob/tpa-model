using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TPA.Model
{
    public class MethodMetadata
    {
        [Key]
        public virtual int Id { get; set; }
        public ICollection<TypeMetadata> GenericArguments { get; set; }
        public virtual AccessLevel? AccessLevel { get; set; }
        public virtual SealedEnum? SealedEnum { get; set; }
        public virtual AbstractEnum? AbstractEnum { get; set; }
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
        public TypeMetadata ReturnType { get; set; }
        public bool IsExtensionMethod { get; set; }
        public ICollection<ParameterMetadata> Parameters { get; set; }
        public ICollection<AttributeMetadata> Attributes { get; set; }



    }
}