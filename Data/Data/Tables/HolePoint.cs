using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class HolePoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("HoleId")]
        [ForeignKey("Hole")]
        public int HoleId { get; set; }

        [Column("X")]
        public double X { get; set; }

        [Column("Y")]
        public double Y { get; set; }

        [Column("Z")]
        public double Z { get; set; }

        public Hole Hole { get; set; }
    }
}
