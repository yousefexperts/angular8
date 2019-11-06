using DotNetCoreArchitecture.Database.Tables;
using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotNetCoreArchitecture.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer("Server=NEWSOFT-TR02;Database=HrModule;User Id=sa; Password=opc@2018;");
            var context = new Context(builder.Options);
            return context;
        }
    }
}
