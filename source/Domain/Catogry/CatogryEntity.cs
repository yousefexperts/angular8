using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Domain
{
    [Table("CatogryItems")]
    public class CatogryEntity
    {
        public CatogryEntity(string Description) { this.Description = Description; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CatogryId { get; set; }

        [Column("Description")]
        public string Description { get; set; }

    }
}
