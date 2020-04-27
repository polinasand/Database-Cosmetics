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
           // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage = "not empty!")]
            [Display(Name = "Name of collection")]
            public string Name { get; set; }
            [Display(Name = "Description")]
            public string Info { get; set; }
            public virtual ICollection<Product> Products { get; set; }
    }
}
