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

        public async Task<List<Project>> GetAllAsync( string? filterby = null, string? data = null)
        {
            var projects = _issueTrackerDbContext.Projects.AsQueryable();
            if (!string.IsNullOrEmpty(filterby) && !string.IsNullOrEmpty(data))
            {
                if (filterby.ToLower() == "name")
                {
                    projects = projects.Where(p => p.Name.Contains(data));
                }
                else if (filterby.ToLower() == "description")
                {
                    projects = projects.Where(p => p.Description.Contains(data));
                }
            }

            return await projects.ToListAsync();
            //return await _issueTrackerDbContext.Projects.ToListAsync();

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
