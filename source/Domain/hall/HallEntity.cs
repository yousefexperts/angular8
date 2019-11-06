using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Domain
{
    [Table("HallReservation")]
    public class HallEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("HallId")]
        public Guid HallId { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("HallName")]
        public string HallName { get; set; }

        public HallEntity(string Description, string HallName)
        {
            this.HallName = HallName;
            this.Description = Description;
        }

    }
}
