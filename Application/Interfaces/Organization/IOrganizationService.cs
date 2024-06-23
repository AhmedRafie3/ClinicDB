using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Organization
{
    public interface IOrganizationService
    {
        public Task<List<TbOrganization>> GetAllOrganization();
        public Task<int> AddOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken);
        public Task<int> UpdateOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken);

    }
}
