using Az204.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Az204.API.Controllers
{
    public class RequirementController : ControllerBase
    {
        private readonly IRequirementRepository requirementRepository;
        public RequirementController(IRequirementRepository requirementRepository)
        {
            this.requirementRepository = requirementRepository;
        }

        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var requirement = requirementRepository.GetAllAsync().Result;
            return Ok(requirement);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            var requirement = requirementRepository.GetByIdAsync(id).Result;
            return Ok(requirement);
        }

        //[HttpPost("CreateAsync/{id}")]
        //public IActionResult CreateAsync(string name)
        //{
        //    var requirement = requirementRepository.InsertAsync;
        //    return Ok(requirement);
        //}
    }
}
