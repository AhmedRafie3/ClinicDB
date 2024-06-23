using Application.Interfaces.Organization;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase, IOrganizationService
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public Task<List<TbOrganization>> GetAllOrganization()
        {
            throw new NotImplementedException();
        }

        [HttpPost("AddOrganization")]
        public Task<int> AddOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken)
        {
            return _organizationService.AddOrganization(tbOrganization, cancellationToken);
        }

        [HttpPost("UpdateOrganization")]
        public Task<int> UpdateOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
