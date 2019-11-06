using System.ComponentModel.DataAnnotations;

namespace DotNetCoreArchitecture.Model
{
    public class ItemModel
    {
        public string ItemName { get; set; }

        public string Description { get; set; }

        public bool IsExist { get; set; }

        public string MaxNum { get; set; }

        public string MinNum { get; set; }

        public string CreateDate { get; set; }

        public string CatogryId { get; set; }
    }
}
