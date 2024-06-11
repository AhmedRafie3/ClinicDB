using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbRole
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TbMasterAdminRole> TbMasterAdminRoles { get; set; } = new List<TbMasterAdminRole>();

    public virtual ICollection<TbStaffRole> TbStaffRoles { get; set; } = new List<TbStaffRole>();
}
