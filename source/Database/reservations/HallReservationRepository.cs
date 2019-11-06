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
    public sealed class HallReservationRepository : EntityFrameworkCoreRelationalRepository<HallReservationEntity>, IHallReservationRepository
    {
        private Context ContextDb { get; set; }
        public HallReservationRepository(Context context) : base(context)
        {
            ContextDb = context;
        }

        public Task<int> AddSync(HallReservationEntity itemModel)
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

        public async Task<HallReservationEntity> FindBySync(Guid id)
        {
            HallReservationEntity hallEntity = null;
            await Task.Run(() =>
            {
                hallEntity = ContextDb.HallReservationEntityies.FindAsync(id).Result;
                return hallEntity;
            });
            return hallEntity;
        }

        public async Task<int> UpdateSync(HallModel hallModel, Guid id)
        {
            await Task.Run(() =>
            {
                var entity = ContextDb.HallReservationEntityies.FindAsync(id).Result;
                entity.StartDate = DateTime.Parse(hallModel.StartDate);
                entity.EndDate = DateTime.Parse(hallModel.EndDate);
                entity.Notes = hallModel.EndDate;
                entity.HallId = hallModel.HallId;

                /*entity.ItemName = itemModel.ItemName;
                entity.MaxNum = itemModel.MaxNum;
                entity.MinNum = itemModel.MinNum;
                entity.CreateDate = itemModel.CreateDate;
                entity.Description = itemModel.Description;
                entity.CatogryId = itemModel.CatogryId;*/
                var guid = Guid.Parse(hallModel.HallId);
                var hall = ContextDb.HallEntities.FirstOrDefault(e => e.HallId == guid);
                entity.HallEntities = hall;
                ContextDb.Update(entity);
                return ContextDb.SaveChangesAsync();
            });
            return 0;
        }
    }
}

