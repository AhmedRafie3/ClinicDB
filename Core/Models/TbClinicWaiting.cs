using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbClinicWaiting
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public int PatientId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual TbClinic Clinic { get; set; } = null!;
}
