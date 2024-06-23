using Application.Interfaces.Organization;
using Application.Repository.IBase;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Classes.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken)
        {
            var data = new TbOrganization();
            data.Email = tbOrganization.Email;
            data.Address = tbOrganization.Address;
            data.DateCreated = tbOrganization.DateCreated;
            data.ActivationStatus = tbOrganization.ActivationStatus;
            data.OrganizationName = tbOrganization.OrganizationName;
            data.Phone = tbOrganization.Phone;
            data.Bio=tbOrganization.Bio;
             _unitOfWork.Repository<TbOrganization>().Create(data);
           var res=await _unitOfWork.CompleteAsync(cancellationToken);
            if(res==0) return 0;
            else return 1;
        }

        public Task<List<TbOrganization>> GetAllOrganization()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateOrganization(TbOrganization tbOrganization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
