using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    [JsonObject(IsReference = true)]
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












        public TypeMetadata()
        {

        }


        public TypeMetadata(Type type) : this(type.Name, type.Namespace, type.IsBuiltIn())
        {
            if (type == null) return;

            Name = type.Name;
            NamespaceName = type.Namespace;
            DeclaringType = EmitDeclaringType(type.DeclaringType);
            Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            ImplementedInterfaces = EmitInterfaces(type.GetInterfaces());

            if (!type.IsGenericTypeDefinition) GenericArguments = null;
            else GenericArguments = EmitGenericArguments(type.GetGenericArguments());

            Modifiers = EmitModifiers(type);
            BaseType = EmitBaseType(type);
            KindOfType = GetTypeKind(type);
            IsBuiltIn = type.IsBuiltIn();

            Fields = EmitFields(type);
            Methods = MethodMetadata.EmitMethods(type.GetMethods());
            //Attributes = EmitAttributes(type.GetCustomAttributes(inherit: false).Cast<AttributeMetadata>());
            TypeProperties = PropertyMetadata.EmitProperties(type.GetProperties());



        }

        private IEnumerable<AttributeMetadata> EmitAttributes(IEnumerable<Attribute> attributes)
        {
            if (attributes.Count() != 0)
            {
                return from Attribute attr in attributes
                       select new AttributeMetadata(attr);
            }
            else
            {
                return null;
            }
        }

        private Tuple<AccessLevel, SealedEnum, AbstractEnum> EmitModifiers(Type type)
        {
            AccessLevel accessModifier = Model.AccessLevel.Private;

            if (type.IsPublic || type.IsNestedPublic)
                accessModifier = Model.AccessLevel.Public;
            else if (type.IsNestedFamily)
                accessModifier = Model.AccessLevel.Protected;
            else
                accessModifier = Model.AccessLevel.Internal;

            SealedEnum sealedModifier = Model.SealedEnum.NotSealed;

            if (type.IsSealed) sealedModifier = Model.SealedEnum.Sealed;

            AbstractEnum abstractModifier = Model.AbstractEnum.NotAbstract;

            if (type.IsAbstract) abstractModifier = Model.AbstractEnum.Abstract;

            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(accessModifier, sealedModifier, abstractModifier);
        }

        private TypeMetadata(string name, string namespaceName, bool isBuiltIn)
        {
            Name = name;
            NamespaceName = namespaceName;
            IsBuiltIn = isBuiltIn;

            usedTypes.Add(namespaceName + "." + name, this);
        }

        private TypeMetadata(string typeName, string namespaceName, ICollection<TypeMetadata> genericArguments, bool isPrimitive) : this(typeName, namespaceName, isPrimitive)
        {
            IsGeneric = true;
            GenericArguments = genericArguments;
        }

        private TypeKind GetTypeKind(Type type)
        {
            if (type.GetTypeInfo().IsEnum) return TypeKind.Enum;
            if (type.GetTypeInfo().IsInterface) return TypeKind.Interface;
            if (type.GetTypeInfo().IsValueType) return TypeKind.Struct;
            return TypeKind.Class;
        }

        private static TypeMetadata EmitDeclaringType(Type declaringType)
        {
            if (declaringType == null) return null;
            else return EmitReference(declaringType);
        }

        private static ICollection<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {

            var help = from type in nestedTypes
                       where type.IsVisible
                       select EmitReference(type);

            Collection<TypeMetadata> col = new Collection<TypeMetadata>();
            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }

        private static ICollection<TypeMetadata> EmitInterfaces(IEnumerable<Type> interfaces)
        {
            var help = from anInterface in interfaces
                       select EmitReference(anInterface);

            Collection<TypeMetadata> col = new Collection<TypeMetadata>();
            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }

        private static TypeMetadata EmitBaseType(Type type)
        {
            if (type == null || type == typeof(Object) || type == typeof(ValueType) || type == typeof(Enum) || type.BaseType == null || type.IsBuiltIn())
                return EmitReference(type);
            else return null;
        }

        private static ICollection<FieldMetadata> EmitFields(Type type)
        {
            var help = from FieldInfo fieldInfo in type.GetRuntimeFields()
                       select new FieldMetadata(fieldInfo);

            Collection<FieldMetadata> col = new Collection<FieldMetadata>();
            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }

        private static Dictionary<String, TypeMetadata> usedTypes = new Dictionary<string, TypeMetadata>();

        static internal TypeMetadata EmitReference(Type type)
        {
            if (usedTypes.Keys.Contains(type.Namespace + "." + type.Name)) return usedTypes[type.Namespace + "." + type.Name];
            else return new TypeMetadata(type);
            //else return new TypeMetadata(type.Name, type.Namespace, EmitGenericArguments(type.GetGenericArguments()), type.IsBuiltIn());
        }

        static internal ICollection<TypeMetadata> EmitGenericArguments(ICollection<Type> arguments)
        {
            var help = from Type argument in arguments
                       select EmitReference(argument);

            Collection<TypeMetadata> col = new Collection<TypeMetadata>();
            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }








    }
}
