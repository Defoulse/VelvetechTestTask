using Microsoft.EntityFrameworkCore;
using TodoApiDTO.Models;

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
