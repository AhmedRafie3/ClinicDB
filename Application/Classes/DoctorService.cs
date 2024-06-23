using Application.Repository.IBase;
using Infrastructure.Interfaces.Doctors;
using Infrastructure.Models;
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

        public Task<List<TbClinic>> AddDoctors()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TbClinic>> GetDoctors()
        {
            return await unitOfWork.Repository<TbClinic>().FindAll().ToListAsync();
        }
    }
}
