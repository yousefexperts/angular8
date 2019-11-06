using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public sealed class ItemRepository : EntityFrameworkCoreRelationalRepository<ItemEntity>, IItemRepository
    {
        private Context ContextDb { get; set; }
        public ItemRepository(Context context) : base(context)
        {
            ContextDb = context;
        }

        public Task<int> AddSync(ItemEntity itemModel)
        {
            ContextDb.Add(itemModel);
            return ContextDb.SaveChangesAsync();
        }

        public async Task<string> ListSync()
        {
            string output = string.Empty;
            await Task.Run(() =>
            {
                output = JsonConvert.SerializeObject(ContextDb.ItemEntities.ToList());
                return output;
            });
            return output;
        }

        public async Task<ItemEntity> FindBySync(Guid id)
        {
            ItemEntity itemEntity = null;
            await Task.Run(() =>
            {
                itemEntity = ContextDb.ItemEntities.FindAsync(id).Result;
                return itemEntity;
            });
            return itemEntity;
        }

        public async Task<int> UpdateSync(ItemModel itemModel, Guid id)
        {
            await Task.Run(() =>
            {
                var entity = ContextDb.ItemEntities.FindAsync(id).Result;
                entity.ItemName = itemModel.ItemName;
                entity.MaxNum = itemModel.MaxNum;
                entity.MinNum = itemModel.MinNum;
                entity.CreateDate = itemModel.CreateDate;
                entity.Description = itemModel.Description;
                entity.CatogryId = itemModel.CatogryId;
                var catogry = ContextDb.CatogryEntities.FirstOrDefault(e => e.Description == itemModel.CatogryId);
                entity.Catogries = catogry;
                ContextDb.Update(entity);
                return ContextDb.SaveChangesAsync();
            });
            return 0;
        }
    }
}

