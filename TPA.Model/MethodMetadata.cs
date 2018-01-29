using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static TPA.Model.TypeMetadata;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TPA.Model
{
    [JsonObject(IsReference = true)]
    public class MethodMetadata
    {
        [Key]
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TypeMetadata> GenericArguments { get; set; }
        public virtual AccessLevel? AccessLevel { get; set; }
        public virtual AbstractEnum? AbstractEnum { get; set; }
        public virtual StaticEnum? StaticEnum { get; set; }
        public virtual VirtualEnum? VirtualEnum { get; set; }
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers 
        {
            get
            {
                return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(AccessLevel.Value, AbstractEnum.Value, StaticEnum.Value, VirtualEnum.Value);
            }
            set
            {
                AccessLevel = value.Item1;
                AbstractEnum = value.Item2;
                StaticEnum = value.Item3;
                VirtualEnum = value.Item4;
            }
        }
        public TypeMetadata ReturnType { get; set; }
        public bool IsExtensionMethod { get; set; }
        public ICollection<ParameterMetadata> Parameters { get; set; }
        public ICollection<AttributeMetadata> Attributes { get; set; }














        public MethodMetadata(MethodBase method)
        {
            Name = method.Name;

            if (!method.IsGenericMethodDefinition) GenericArguments = null;
            else GenericArguments = TypeMetadata.EmitGenericArguments(method.GetGenericArguments());

            Modifiers = EmitModifiers(method);

            // IsExtensionMethod = EmitIsExtensionMethod(method);
            ReturnType = EmitReturnType(method);
            Parameters = EmitParameters(method.GetParameters().ToArray());

        }

        //static internal IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        //{
        //    return from MethodBase method in methods
        //           select new MethodMetadata(method);
        //}

        static internal ICollection<MethodMetadata> EmitMethods(ICollection<MethodBase> methods)
        {
            var help = from MethodBase method in methods
                       select new MethodMetadata(method);

            Collection<MethodMetadata> col = new Collection<MethodMetadata>();
            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }

        private static bool EmitIsExtensionMethod(MethodBase method)
        {
            return method.IsDefined(typeof(ExtensionAttribute), false);
        }

        private static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> EmitModifiers(MethodBase method)
        {
            AccessLevel accessModifier = Model.AccessLevel.Private;

            if (method.IsPublic) accessModifier = Model.AccessLevel.Public;
            else if (method.IsFamily) accessModifier = Model.AccessLevel.Protected;
            else if (method.IsFamilyAndAssembly) accessModifier = Model.AccessLevel.Internal;

            AbstractEnum abstractModifier = Model.AbstractEnum.NotAbstract;

            if (method.IsAbstract) abstractModifier = Model.AbstractEnum.Abstract;

            StaticEnum staticModifier = Model.StaticEnum.NonStatic;
            if (method.IsStatic) staticModifier = Model.StaticEnum.Static;

            VirtualEnum virtualModifier = Model.VirtualEnum.NonVirtual;

            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(accessModifier, abstractModifier, staticModifier, virtualModifier);
        }

        private static ICollection<ParameterMetadata> EmitParameters(ParameterInfo[] parameters)
        {
            return (from ParameterInfo pInfo in parameters
                   select new ParameterMetadata(pInfo.Name, TypeMetadata.EmitReference(pInfo.ParameterType))).ToList();
        }

        private static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null) return null;
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }

        public MethodMetadata()
        {

        }


    }
}