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
    }
}
