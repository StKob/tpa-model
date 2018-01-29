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
    public class PropertyMetadata
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Type")]
        public virtual int TypeId { get; set; }
        public TypeMetadata Type { get; set; }



        public PropertyMetadata(PropertyInfo propertyInfo)
        {
            this.Name = propertyInfo.Name;
            this.Type = TypeMetadata.EmitReference(propertyInfo.PropertyType);
            //this.Type = new TypeMetadata(propertyInfo.PropertyType);
        }


        //internal static IEnumerable<PropertyMetadata> EmitProperties(PropertyInfo[] propertyInfo)
        //{
        //    return from PropertyInfo prop in propertyInfo
        //           select new PropertyMetadata(prop);
        //}

        internal static ICollection<PropertyMetadata> EmitProperties(PropertyInfo[] propertyInfo)
        {
            var help = from PropertyInfo prop in propertyInfo
                       select new PropertyMetadata(prop);

            Collection<PropertyMetadata> col = new Collection<PropertyMetadata>();

            foreach (var item in help)
            {
                col.Add(item);
            }
            return col;
        }

        public PropertyMetadata()
        {

        }



    }
}
