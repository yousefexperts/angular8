using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Model;
namespace DotNetCoreArchitecture.Application
{
    public interface IHallApplicationService
    {
        Task<IDataResult<long>> AddAsync(CatogryModel itemModel);

        Task<string> ListAsync();

    }
}
