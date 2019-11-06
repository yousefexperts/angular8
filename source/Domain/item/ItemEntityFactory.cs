using DotNetCoreArchitecture.Model;
using DotNetCoreArchitecture.Domain;

namespace DotNetCoreArchitecture.Domain
{
    public static class ItemEntityFactory
    {
        public static ItemEntity Create(ItemModel itemModel)
        {
            return new ItemEntity
            (
                itemModel.ItemName,
                itemModel.Description,
                itemModel.MaxNum,
                itemModel.MinNum,
                itemModel.CreateDate,
                itemModel.IsExist,
                itemModel.CatogryId
            );
        }
    }
}
