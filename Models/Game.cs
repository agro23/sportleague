using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLeague.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public string Versus { get; set; }
        public string Score { get; set; }
        public virtual ICollection<League> Leagues { get; set; }

    }
}
