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
        public DbSet<AttributeMetadata> AttributeMetadatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeMetadata>()
                .HasMany(t => t.GenericArguments)
                .WithOptional(t => t.IsTemplateIn)
                .HasForeignKey<int?>(t => t.IsTemplateInId);

            modelBuilder.Entity<TypeMetadata>()
                .HasMany(t => t.NestedTypes)
                .WithOptional(t => t.IsNestedIn)
                .HasForeignKey<int?>(t => t.IsNestedInId);

            modelBuilder.Entity<TypeMetadata>()
                .HasMany<AttributeMetadata>(t => t.Attributes)
                .WithMany(a => a.TypesUsingThisAttribute)
                .Map(cs =>
                {
                    cs.MapLeftKey("TypeId");
                    cs.MapRightKey("AttributeId");
                    cs.ToTable("TypesAttributes");
                });


            modelBuilder.Entity<TypeMetadata>()
                .HasMany<TypeMetadata>(t => t.ImplementedInterfaces)
                .WithMany(t => t.TypesImplementingThisInterface)
                .Map(cs =>
                {
                    cs.MapLeftKey("ImplementorId");
                    cs.MapRightKey("InterfaceId");
                    cs.ToTable("TypesInterfaces");
                });
        }
    }
}
