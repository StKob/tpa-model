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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeMetadata>()
                .HasMany(t => t.GenericArguments)
                .WithOptional(t => t.IsTemplateIn)
                .HasForeignKey<int?>(t => t.IsTemplateInId);      
        }
    }
}
