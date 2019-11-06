using DotNetCoreArchitecture.Model;
using DotNetCoreArchitecture.Domain;

namespace DotNetCoreArchitecture.Domain
{
    public static class HallEntityFactory
    {
        public static HallEntity Create(HallModel hallModel)
        {
            return new HallEntity
            (
                HallName: hallModel.HallName,
                Description: hallModel.Description
            );
        }
    }
}
