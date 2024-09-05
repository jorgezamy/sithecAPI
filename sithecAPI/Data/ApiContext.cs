using Microsoft.EntityFrameworkCore;

namespace sithecAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {

        }
    }
}
