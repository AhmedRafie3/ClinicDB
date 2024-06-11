using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbReservation
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    public int UserId { get; set; }

    public DateTime ReservationDate { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbClinic Clinic { get; set; } = null!;

    public virtual TbUser User { get; set; } = null!;
}
