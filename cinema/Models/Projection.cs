using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("projection")]
    public partial class Projection
    {
        public Projection()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Movie_Id", TypeName = "int(11)")]
        public int MovieId { get; set; }
        [Column("ProjectionHour_Id", TypeName = "int(11)")]
        public int ProjectionHourId { get; set; }
        [Column("Theater_Id", TypeName = "int(11)")]
        public int TheaterId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Projection")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(ProjectionHourId))]
        [InverseProperty(nameof(Projectionhour.Projection))]
        public virtual Projectionhour ProjectionHour { get; set; }
        [ForeignKey(nameof(TheaterId))]
        [InverseProperty("Projection")]
        public virtual Theater Theater { get; set; }
        [InverseProperty("Projection")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
