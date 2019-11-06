using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Database.Tables
{
    [Table("CatogriesTable")]
    public class CatogriesTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Column("Value")]
        public string Value { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}
