using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("ticket")]
    public partial class Ticket
    {
        public Ticket()
        {
            Receipt = new HashSet<Receipt>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Projection_Id", TypeName = "int(11)")]
        public int ProjectionId { get; set; }
        [Column("Seat_Id", TypeName = "int(11)")]
        public int SeatId { get; set; }

        [ForeignKey(nameof(ProjectionId))]
        [InverseProperty("Ticket")]
        public virtual Projection Projection { get; set; }
        [ForeignKey(nameof(SeatId))]
        [InverseProperty("Ticket")]
        public virtual Seat Seat { get; set; }
        [InverseProperty("Ticket")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
