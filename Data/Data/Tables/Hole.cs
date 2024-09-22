using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class Hole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column("DrillBlockId")]
        [ForeignKey("DrillBlock")]
        public int DrillBlockId { get; set; }

        [Column("DEPTH")]
        public double DEPTH { get; set; }

        public DrillBlock DrillBlock { get; set; }

        public ICollection<HolePoint> HolePoints { get; set; }
    }
}
