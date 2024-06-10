using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbMasterAdminRole
{
    public int Id { get; set; }

    public int MasterAdminId { get; set; }

    public int RoleId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbMasterAdmin MasterAdmin { get; set; } = null!;

    public virtual TbRole Role { get; set; } = null!;
}
