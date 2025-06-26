using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data.Models;
using EntityFramework.Data.Models.Domain;

namespace IssueTrackerRepo
{
    public class ProjectRepo :IProjectsRepo
    {

        private readonly IssueTrackerDbContext _issueTrackerDbContext;
        public ProjectRepo(IssueTrackerDbContext issueTrackerDbContext)
        {
            _issueTrackerDbContext = issueTrackerDbContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _issueTrackerDbContext.Projects.ToListAsync();

        }
    }
}
