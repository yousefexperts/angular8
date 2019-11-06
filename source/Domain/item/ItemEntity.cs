using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreArchitecture.Domain
{
    [Table("ItemInventory")]
    public class ItemEntity
    {
        public ItemEntity(string ItemName, string Description, string MaxNum, string MinNum, string CreateDate, bool IsExist, string CatogryId)
        {
            this.CreateDate = CreateDate;
            this.IsExist = IsExist;
            this.Description = Description;
            this.ItemName = ItemName;
            this.MaxNum = MaxNum;
            this.MinNum = MinNum;
            this.CatogryId = CatogryId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ItemId { get; set; }

        [Column("ItemName")]
        public string ItemName { get; set; }

        [Column("CreateDate")]
        public string CreateDate { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("IsExist")]
        public bool IsExist { get; set; }

        [Column("MaxNum")]
        public string MaxNum { get; set; }

        [Column("MinNum")]
        public string MinNum { get; set; }

        [ForeignKey("CatogryId")]
        public string CatogryId { get; set; }
        public CatogryEntity Catogries { get; set; }
    }
}
