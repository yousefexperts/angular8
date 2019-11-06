using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using DotNetCoreArchitecture.Database.Tables;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;
namespace DotNetCoreArchitecture.Database
{

    public interface IHallReservationRepository : IRelationalRepository<HallReservationEntity>
    {
        public Task<int> AddSync(HallReservationEntity hallEntity);

        public Task<int> UpdateSync(HallModel HallModel, Guid id);

        public Task<string> ListSync();

        public Task<HallReservationEntity> FindBySync(Guid id);

        //Task<ItemModel> UpdateAsync(ItemModel ItemModel);
        //Task<ItemModel> DeleteAsync(ItemModel ItemModel);

    }
}
