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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var allProjects = await _projectRepo.GetbyId(id);
            return Ok(allProjects);
        }

        [HttpPost]
        public async  Task<IActionResult> AddProject ([FromBody] ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var project_ = new Project 
            { 
                Name = projectDTO.Name,
                Description = projectDTO.Description
            };

            var _project = await _projectRepo.CreateProject(project_);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DelteProject(Guid id)
        {
            var _project = await _projectRepo.DeleteProject(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectDTO _project)
        {
            var project_ = new Project { Name = _project.Name, Description = _project.Description };
            var _ = await _projectRepo.UpdateProject(project_);
            return Ok();
        }
    }
}
