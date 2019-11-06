using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreArchitecture.Domain
{
    public class CatogryEntityFactory
    {
        public static CatogryEntity Create(string Description)
        {
            return new CatogryEntity(Description); ;
        }
    }

}
