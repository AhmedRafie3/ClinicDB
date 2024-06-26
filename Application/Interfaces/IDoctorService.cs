using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        Task<List<TbClinic>> GetDoctors();
        Task<List<TbClinic>> AddDoctors();
    }
}
