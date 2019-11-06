using DotNetCore.Objects;
using DotNetCore.Repositories;
using DotNetCoreArchitecture.Database.Tables;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public interface IItemRepository : IRelationalRepository<ItemEntity>
    {
        public Task<int> AddSync(ItemEntity ItemModel);

        public Task<int> UpdateSync(ItemModel ItemModel, Guid id);

        public Task<string> ListSync();

        public Task<ItemEntity> FindBySync(Guid id);

        //Task<ItemModel> UpdateAsync(ItemModel ItemModel);
        //Task<ItemModel> DeleteAsync(ItemModel ItemModel);
    }
}
