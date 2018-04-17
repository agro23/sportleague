using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLeague.Models
{
    [Table("Leagues")]
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
    }
}
