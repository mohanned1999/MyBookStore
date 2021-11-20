using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<DbContext> options):base(options)
        {


        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
    }
}
