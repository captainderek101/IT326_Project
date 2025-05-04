using Microsoft.EntityFrameworkCore;

namespace Ups_Downs_API.ApiService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
