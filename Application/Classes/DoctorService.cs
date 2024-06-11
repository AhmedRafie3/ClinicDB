using Application.Interfaces.Repositories.Base;
using Infrastructure.Interfaces.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Classes
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        public DoctorService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<List<object>> GetDoctors()
        {
            return await unitOfWork.Repository<object>().FindAll().ToListAsync();
        }
    }
}
