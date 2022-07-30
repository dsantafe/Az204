using Az204.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Az204.Domain.Repositories.Implements
{
    internal class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(Az204Context context) : base(context)
        {
        }
    }
}
