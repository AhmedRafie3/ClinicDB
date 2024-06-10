using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbOrganization
{
    public int Id { get; set; }

    public string OrganizationName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public bool? ActivationStatus { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual ICollection<TbClinic> TbClinics { get; set; } = new List<TbClinic>();

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
