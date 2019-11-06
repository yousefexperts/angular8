using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Database.Tables
{
    [Table("InventoryTable")]
    public class ItemsInventoryTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Column("ItemName")]
        public string ItemName { get; set; }

        [Column("ItemDescription")]
        public string ItemDescription { get; set; }

        [Column("MaxNum")]
        public int MaxNum { get; set; }

        [Column("MinNum")]
        public int MinNum { get; set; }

        [Column("IsExist")]
        public bool IsExist { get; set; }

        [Column("CatogriesTableId")]
        public ICollection<CatogriesTable> CatogriesTables { get; set; }

    }
}
