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
    public interface IHallRepository : IRelationalRepository<HallEntity>
    {
        public Task<int> AddSync(HallEntity hallEntity);

        public Task<int> UpdateSync(HallModel HallModel, Guid id);

        public Task<string> ListSync();

        public Task<HallEntity> FindBySync(Guid id);

        //Task<ItemModel> UpdateAsync(ItemModel ItemModel);
        //Task<ItemModel> DeleteAsync(ItemModel ItemModel);
    }
}
