using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbClinicStaff
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public int UserId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbClinic Clinic { get; set; } = null!;

    public virtual ICollection<TbStaffRole> TbStaffRoles { get; set; } = new List<TbStaffRole>();

    public virtual TbUser User { get; set; } = null!;
}
