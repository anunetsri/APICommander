using APICommander.Models;
using Microsoft.EntityFrameworkCore;

namespace APICommander.Data
{
    public class APICommanderContext: DbContext
    {
        public APICommanderContext(DbContextOptions<APICommanderContext> opt) : base(opt)
        {
            
        }
        //Represent our command object down to our DB as our DBset
        //But no connection on Database
        public DbSet<APICommand> Commands { get; set; }
    }
}