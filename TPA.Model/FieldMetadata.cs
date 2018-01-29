using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

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



        public FieldMetadata(FieldInfo fieldInfo)
        {
            this.Name = fieldInfo.Name;
            this.Type = TypeMetadata.EmitReference(fieldInfo.FieldType);
            this.StaticModifier = EmitStaticnessModifier(fieldInfo);
            this.AccessModifier = EmitAccessModifier(fieldInfo);
        }

        private AccessLevel EmitAccessModifier(FieldInfo field)
        {
            AccessLevel accessModifier = AccessLevel.Internal;

            if (field.IsPublic)
                accessModifier = AccessLevel.Public;
            else if (field.IsFamily)
                accessModifier = AccessLevel.Protected;

            return accessModifier;
        }

        private StaticEnum EmitStaticnessModifier(FieldInfo fieldInfo)
        {
            var mdf = StaticEnum.NonStatic;
            if (fieldInfo.IsStatic) mdf = StaticEnum.Static;

            return mdf;
        }

        internal static ICollection<PropertyMetadata> EmitFields(FieldInfo[] propertyInfo)
        {
            return (from PropertyInfo prop in propertyInfo
                    select new PropertyMetadata(prop)).ToList();
        }

        public FieldMetadata()
        {

        }
    }
}