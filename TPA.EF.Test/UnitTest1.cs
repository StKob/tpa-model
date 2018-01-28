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

            nspaces.Add(new NamespaceMetadata());
            nspaces.Add(new NamespaceMetadata());
            nspaces.Add(new NamespaceMetadata());

            assemblyMetadata.Namespaces = nspaces;

            context.AssemblyMetadatas.Add(assemblyMetadata);

            context.SaveChanges();
        }


    }
}
