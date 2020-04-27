using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseCosmetics.Models
{
    public class Color
    {
        public Color()
        {
            Products = new List<Product>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "not empty!")]
        [Display(Name = "Color")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
