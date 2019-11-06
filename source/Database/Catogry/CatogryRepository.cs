using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public sealed class CatogryRepository : EntityFrameworkCoreRelationalRepository<CatogryEntity>, ICatogryRepository
    {
        private Context ContextDb { get; set; }
        public CatogryRepository(Context context) : base(context)
        {
            ContextDb = context;
        }

        public Task<int> AddSync(CatogryEntity itemModel)
        {
            ContextDb.Add(itemModel);
            return ContextDb.SaveChangesAsync();
        }

        public async Task<string> ListSync()
        {
            var result = string.Empty;
            await Task.Run(() =>
            {
                result = JsonConvert.SerializeObject(ContextDb.CatogryEntities.ToList().Select(e => e.Description));
                return result;
            });
            return result;
        }
    }
}
