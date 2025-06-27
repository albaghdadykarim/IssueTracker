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
using EntityFramework.Data.Models.DTOs;

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
        public async Task<Project?> GetbyId(Guid Id)
        {
            var _project = await _issueTrackerDbContext.Projects.FirstOrDefaultAsync(p => p.Id == Id);
            return _project;

        }
        public async Task<Project> CreateProject(Project _project)
        {
            await _issueTrackerDbContext.Projects.AddAsync(_project);
            await _issueTrackerDbContext.SaveChangesAsync();

            return _project;

        }
        public async Task<Project?> DeleteProject(Guid id)
        {
            var _project = await _issueTrackerDbContext.Projects.FirstOrDefaultAsync(_project => _project.Id == id);
            if (_project == null)
            {
                return null; 
            }
            _issueTrackerDbContext.Projects.Remove(_project);
            await _issueTrackerDbContext.SaveChangesAsync();

            return _project;

        }
        public async Task<Project?> UpdateProject(Project project)
        {

            var _project = await _issueTrackerDbContext.Projects.FirstOrDefaultAsync(_project => _project.Id == project.Id);
            if (_project == null)
            {
                return null; 
            }

            _project.Name = project.Name;
            _project.Description = project.Description;

            await _issueTrackerDbContext.SaveChangesAsync();

            return _project;

        }
    }
}
