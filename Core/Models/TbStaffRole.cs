using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbStaffRole
{
    public int Id { get; set; }

    public int ClinicStaffId { get; set; }

    public int RoleId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbClinicStaff ClinicStaff { get; set; } = null!;

    public virtual TbRole Role { get; set; } = null!;
}
