using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("projectionhour")]
    public partial class Projectionhour
    {
        public Projectionhour()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        public TimeSpan Hour { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }

        [InverseProperty("ProjectionHour")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
