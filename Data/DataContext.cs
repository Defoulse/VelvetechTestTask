using Microsoft.EntityFrameworkCore;
using TodoApiDTO.Dtos;

namespace TodoApiDTO.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }    

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
