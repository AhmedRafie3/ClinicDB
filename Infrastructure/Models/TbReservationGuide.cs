using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbReservationGuide
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public TimeOnly? SatStart { get; set; }

    public TimeOnly? SatEnd { get; set; }

    public int? SatTimeShift { get; set; }

    public TimeOnly? SunStart { get; set; }

    public TimeOnly? SunEnd { get; set; }

    public int? SunTimeShift { get; set; }

    public TimeOnly? MonStart { get; set; }

    public TimeOnly? MonEnd { get; set; }

    public int? MonTimeShift { get; set; }

    public TimeOnly? TueStart { get; set; }

    public TimeOnly? TueEnd { get; set; }

    public int? TueTimeShift { get; set; }

    public TimeOnly? WedStart { get; set; }

    public TimeOnly? WedEnd { get; set; }

    public int? WedTimeShift { get; set; }

    public TimeOnly? ThuStart { get; set; }

    public TimeOnly? ThuEnd { get; set; }

    public int? ThuTimeShift { get; set; }

    public TimeOnly? FriStart { get; set; }

    public TimeOnly? FriEnd { get; set; }

    public int? FriTimeShift { get; set; }

    public int ReservationDuration { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbClinic Clinic { get; set; } = null!;
}
