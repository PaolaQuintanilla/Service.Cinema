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
        [Column("Movie_Id", TypeName = "int(11)")]
        public int MovieId { get; set; }
        [Column("Seat_Id", TypeName = "int(11)")]
        public int SeatId { get; set; }
        [Column("ProjectionHour_Id", TypeName = "int(11)")]
        public int ProjectionHourId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Ticket")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(ProjectionHourId))]
        [InverseProperty(nameof(Projectionhour.Ticket))]
        public virtual Projectionhour ProjectionHour { get; set; }
        [ForeignKey(nameof(SeatId))]
        [InverseProperty("Ticket")]
        public virtual Seat Seat { get; set; }
        [InverseProperty("Ticket")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
