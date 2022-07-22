using Az204.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Az204.Domain.Repositories.Implements
{
    public class RequirementRepository : GenericRepository<Requirement>, IRequirementRepository
    {
        public RequirementRepository(Az204Context context) : base(context)
        {

        }
    }
}
