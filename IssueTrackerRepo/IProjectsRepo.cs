using EntityFramework.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerRepo
{
    public interface IProjectsRepo
    {

        public Task<List<Project>> GetAllAsync();

        public Task<Project?> GetbyId(Guid Id);

        public  Task<Project> CreateProject(Project _project);
        public Task<Project?> DeleteProject(Guid id);

        public Task<Project?> UpdateProject(Project project);
    }
}
