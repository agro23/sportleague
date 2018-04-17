using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLeague.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Stats { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
