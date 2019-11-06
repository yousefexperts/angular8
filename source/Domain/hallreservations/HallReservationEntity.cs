using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Domain
{
    [Table("HallReservationDateSchedule")]
    public class HallReservationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReservationId { get; set; }

        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Column("enddate")]
        public DateTime EndDate { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [ForeignKey("HallId")]
        public string HallId { get; set; }
        public HallEntity HallEntities { get; set; }

        public HallReservationEntity(string stratdate, string enddate, string notes, string hallId)
        {
            StartDate = DateTime.Parse(stratdate);
            EndDate = DateTime.Parse(enddate);
            Notes = notes;
            HallId = hallId;
        }
    }
}
