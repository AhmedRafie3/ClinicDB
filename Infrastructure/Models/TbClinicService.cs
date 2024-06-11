using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbClinicService
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public int ServiceId { get; set; }

    public decimal? Fees { get; set; }

    public virtual TbClinic Clinic { get; set; } = null!;

    public virtual TbStaticDatum Service { get; set; } = null!;
}
