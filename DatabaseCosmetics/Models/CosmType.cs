using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DatabaseCosmetics.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCosmetics.Models
{
    public class CosmType
    {
        public CosmType()
        {
            Products = new List<Product>();
        }
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "not empty!")]
        [Display(Name = "Type")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
