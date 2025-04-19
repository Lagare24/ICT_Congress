using Microsoft.EntityFrameworkCore;

namespace TeamDebugger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
