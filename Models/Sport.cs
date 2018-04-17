using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLeague.Models
{
    [Table("Sports")]
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
