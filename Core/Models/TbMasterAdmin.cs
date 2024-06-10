using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbMasterAdmin
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[] DateCreated { get; set; } = null!;

    public virtual ICollection<TbMasterAdminRole> TbMasterAdminRoles { get; set; } = new List<TbMasterAdminRole>();
}
