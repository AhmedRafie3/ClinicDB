using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class RegisterationRequest
    {
        public int Id { get; set; }

        public int UserTypeId { get; set; }
        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ImageKey { get; set; }

        public bool ActivationStatus { get; set; }

        public bool EnableCrossEdit { get; set; }

        public string DateCreated { get; set; } = null!;
    }
}
