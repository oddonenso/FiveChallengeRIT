using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Tables
{
    public class DrillBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        public ICollection<Hole> Holes { get; set; }

        public ICollection<DrillBlockPoint> DrillBlockPoints { get; set; }
    }
}
