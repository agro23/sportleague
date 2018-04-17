using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLeague.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> players { get; set; }

    }
}
