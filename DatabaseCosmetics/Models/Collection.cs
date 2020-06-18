using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCosmetics.Models
{
    public class Collection
    {
            public Collection()
            {
                Products = new List<Product>();
            }
            [Key]
            public int Id { get; set; }
           
            public string Name { get; set; }
            
            public string Info { get; set; }
            public virtual ICollection<Product> Products { get; set; }
    }
}
