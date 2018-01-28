using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Model;
using System.Collections.Generic;

namespace TPA.EF.Test
{
    [TestClass]
    public class ORMTest
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    AssemblyMetadataDbContext context = new Model.AssemblyMetadataDbContext();

        //    AssemblyMetadata assemblyMetadata = new AssemblyMetadata();
        //    assemblyMetadata.Name = "MyAssembly1";

        //    context.AssemblyMetadatas.Add(assemblyMetadata);

        //    context.SaveChanges();
        //}

        [TestMethod]
        public void TestMethod2()
        {
            AssemblyMetadataDbContext context = new Model.AssemblyMetadataDbContext();

            AssemblyMetadata assemblyMetadata = new AssemblyMetadata();
            assemblyMetadata.Name = "MyAssembly1";

            List<NamespaceMetadata> nspaces = new List<NamespaceMetadata>();

            var n1 = new NamespaceMetadata();
            var n2 = new NamespaceMetadata();
            var n3 = new NamespaceMetadata();

            n1.Name = "n1name";
            n2.Name = "n2name";
            n3.Name = "n3name";

            var t1 = new TypeMetadata();
            t1.Name = "t1Name";
            var t2 = new TypeMetadata();
            t2.Name = "t2Name";
            var t3 = new TypeMetadata();
            t3.Name = "t3Name";


            n1.Types = new List<TypeMetadata>()
            {
                t1
            };

            t1.NamespaceName = n1.Name;

            n2.Types = new List<TypeMetadata>()
            {
                t2, t3
            };

            t2.NamespaceName = n2.Name;
            t3.NamespaceName = n2.Name;
            t3.BaseType = t2;



            nspaces.Add(n1);
            nspaces.Add(n2);
            nspaces.Add(n3);

            assemblyMetadata.Namespaces = nspaces;

            context.AssemblyMetadatas.Add(assemblyMetadata);

            context.SaveChanges();
        }


    }
}
