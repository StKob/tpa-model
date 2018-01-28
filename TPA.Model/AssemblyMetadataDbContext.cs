using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Model
{
    public class AssemblyMetadataDbContext : DbContext
    {
          public DbSet<AssemblyMetadata> AssemblyMetadatas { get; set; }
          public DbSet<NamespaceMetadata> NamespaceMetadatas { get; set; }
          public DbSet<TypeMetadata> TypeMetadatas { get; set; }
    }
}
