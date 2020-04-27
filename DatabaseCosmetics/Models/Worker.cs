using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCosmetics.Models
{
    public class Worker
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public int PositionId { get; set; }
        public virtual Store Store { get; set; }
        public virtual Position Position { get; set; }

    }
}
