using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbMedicalRecordDoctor
{
    public int Id { get; set; }

    public int MedicalRecordId { get; set; }

    public int DoctorId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbUser Doctor { get; set; } = null!;

    public virtual TbMedicalRecord MedicalRecord { get; set; } = null!;
}
