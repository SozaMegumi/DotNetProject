using Microsoft.EntityFrameworkCore;
using DotNetProject.Models;
using System.Collections.Generic;

namespace DotNetProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
