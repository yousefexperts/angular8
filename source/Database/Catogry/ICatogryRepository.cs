using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCore.Repositories;
using DotNetCoreArchitecture.Domain;
namespace DotNetCoreArchitecture.Database
{
    public interface ICatogryRepository : IRelationalRepository<CatogryEntity>
    {
        public Task<int> AddSync(CatogryEntity ItemModel);
        public Task<string> ListSync();
    }
}
