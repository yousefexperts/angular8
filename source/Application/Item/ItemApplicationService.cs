using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DotNetCoreArchitecture.Application
{
    public sealed class ItemApplicationService : IItemApplicationService
    {
        public ItemApplicationService(IItemRepository ItemRepository, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            IItemRepository = ItemRepository;
        }

        private IUnitOfWork UnitOfWork { get; }

        private IItemRepository IItemRepository { get; }

        public async Task<IDataResult<long>> AddAsync(ItemModel itemModel)
        {
            var validation = new ItemAddValidator().Validate(itemModel);

            if (validation.IsError)
            {
                return DataResult<long>.Error(validation.Message);
            }
            var CatogryItem = CatogryEntityFactory.Create(itemModel.CatogryId);

            var itemEntity = ItemEntityFactory.Create(itemModel);

            itemEntity.Catogries = CatogryItem;

            await IItemRepository.AddAsync(itemEntity);
            await UnitOfWork.SaveChangesAsync();

            return DataResult<long>.Success(itemModel.ItemName);
        }

        public async Task<string> ListAsync()
        {
            var items = await IItemRepository.ListSync();
            return items;
        }


        public async Task<ItemModel> FindBySync(Guid id)
        {
            var items = await IItemRepository.FindBySync(id);
            ItemModel itemModel = new ItemModel
            {
                CatogryId = items.CatogryId,
                CreateDate = items.CreateDate,
                Description = items.Description,
                IsExist = items.IsExist,
                ItemName = items.ItemName,
                MaxNum = items.MaxNum,
                MinNum = items.MinNum
            };

            return itemModel;
        }

        public async Task<IDataResult<long>> UpdateAsync(ItemModel itemModel, Guid id)
        {
            var validation = new ItemAddValidator().Validate(itemModel);

            if (validation.IsError)
            {
                return DataResult<long>.Error(validation.Message);
            }
            /*var CatogryItem = CatogryEntityFactory.Create(itemModel.CatogryId);

            var itemEntity = ItemEntityFactory.Create(itemModel);

            itemEntity.Catogries = CatogryItem;*/

            await IItemRepository.UpdateSync(itemModel, id);
            await UnitOfWork.SaveChangesAsync();

            return DataResult<long>.Success(itemModel.ItemName);
        }

    }
}
