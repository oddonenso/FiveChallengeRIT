using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
    public class DrillBlockPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DrillBlockId")]
        [ForeignKey("DrillBlock")]
        public int DrillBlockId { get; set; }

        [Column("Sequence")]
        public int Sequence { get; set; }

        [Column("X")]
        public double X { get; set; }

        [Column("Y")]
        public double Y { get; set; }

        [Column("Z")]
        public double Z { get; set; }

        public DrillBlock DrillBlock { get; set; }
    }
}
