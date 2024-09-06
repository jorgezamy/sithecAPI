using Microsoft.EntityFrameworkCore;
using sithecAPI.Models.Entities;
using System.Data;

namespace sithecAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {

        }

        public DbSet<Humano> Humanos { get; set; }
    }
}
