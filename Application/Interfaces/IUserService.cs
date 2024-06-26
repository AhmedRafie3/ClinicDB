using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<string> AuthenticateUser(AuthenticationRequest request);
        public Task<bool> RegisterUser(RegisterationRequest request, CancellationToken cancellationToken);
    }
}
