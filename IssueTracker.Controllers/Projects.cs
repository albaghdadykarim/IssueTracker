using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using EntityFramework.Data;
using EntityFramework.Data.Models.Domain;
using EntityFramework.Data.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Projects :ControllerBase
    {
        private readonly IssueTrackerDbContext _issueTrackerDbContext;
        public Projects(IssueTrackerDbContext issueTrackerDbContext)
        {
            _issueTrackerDbContext = issueTrackerDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_issueTrackerDbContext.Projects.ToList());
        }

        [HttpPost]
        public IActionResult AddProject ([FromBody] ProjectDTO projectDTO)
        {
            var project_ = new Project 
            { 
                Name = projectDTO.Name,
                Description = projectDTO.Description
            };
            _issueTrackerDbContext.Projects.Add(project_);
            _issueTrackerDbContext.SaveChanges();
            return Ok();
        }
    }
}
