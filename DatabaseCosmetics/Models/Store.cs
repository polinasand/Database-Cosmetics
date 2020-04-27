using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCosmetics.Models
{
    public class Store
    {
        public Store()
        {
            Workers = new List<Worker>();
            Stock = new List<Stock>();
        }
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
