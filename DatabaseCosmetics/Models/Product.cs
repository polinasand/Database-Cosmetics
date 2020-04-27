using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCosmetics.Models
{
    public class Product
    {
        public Product()
        {
            Stock = new List<Stock>();
        }
        [Key()]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "not empty!")]
        [Display(Name = "Price")]
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int? CollectionId { get; set; }
        public int? CosmTypeId { get; set; }
        public int? ColorId { get; set; }
        public int?  FinishId { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
        public virtual CosmType CosmType { get; set; }

    }
}
