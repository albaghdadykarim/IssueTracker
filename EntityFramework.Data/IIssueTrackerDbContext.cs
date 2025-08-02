using EntityFramework.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public interface IIssueTrackerDbContext
    {

         DbSet<User> Users { get; set; }
         DbSet<Project> Projects { get; set; }
         DbSet<Issue> Issues { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
