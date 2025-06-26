using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using EntityFramework.Data;
using EntityFramework.Data.Models.Domain;
using EntityFramework.Data.Models.DTOs;
using IssueTrackerRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Projects :ControllerBase
    {
        private readonly IssueTrackerDbContext _issueTrackerDbContext;
        private readonly IProjectsRepo _projectRepo;
        public Projects(IssueTrackerDbContext issueTrackerDbContext ,IProjectsRepo projectRepo)
        {
            _issueTrackerDbContext = issueTrackerDbContext;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allProjects = await _projectRepo.GetAllAsync();
            return Ok(allProjects);
        }

        [HttpPost]
        public async  Task<IActionResult> AddProject ([FromBody] ProjectDTO projectDTO)
        {
            var project_ = new Project 
            { 
                Name = projectDTO.Name,
                Description = projectDTO.Description
            };
            await _issueTrackerDbContext.Projects.AddAsync(project_);
            await _issueTrackerDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
