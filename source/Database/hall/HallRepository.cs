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
    public sealed class HallRepository : EntityFrameworkCoreRelationalRepository<HallEntity>, IHallRepository
    {
        private Context ContextDb { get; set; }
        public HallRepository(Context context) : base(context)
        {
            ContextDb = context;
        }

        public Task<int> AddSync(HallEntity itemModel)
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

        public async Task<HallEntity> FindBySync(Guid id)
        {
            HallEntity hallEntity = null;
            await Task.Run(() =>
            {
                hallEntity = ContextDb.HallEntities.FindAsync(id).Result;
                return hallEntity;
            });
            return hallEntity;
        }

        public async Task<int> UpdateSync(HallModel hallModel, Guid id)
        {
            await Task.Run(() =>
            {
                var entity = ContextDb.HallEntities.FindAsync(id).Result;
                entity.HallName = hallModel.HallName;
                entity.Description = hallModel.Description;
                /*entity.ItemName = itemModel.ItemName;
                entity.MaxNum = itemModel.MaxNum;
                entity.MinNum = itemModel.MinNum;
                entity.CreateDate = itemModel.CreateDate;
                entity.Description = itemModel.Description;
                entity.CatogryId = itemModel.CatogryId;*/
                /*var guid = Guid.Parse(hallModel.HallId);
                var catogry = ContextDb.HallEntities.FirstOrDefault(e => e.HallId == guid);
                entity. = catogry;*/
                ContextDb.Update(entity);
                return ContextDb.SaveChangesAsync();
            });
            return 0;
        }
    }
}

