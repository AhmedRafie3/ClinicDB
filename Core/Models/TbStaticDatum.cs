using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbStaticDatum
{
    public int Id { get; set; }

    public int? StaticDataTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual TbStaticDataType? StaticDataType { get; set; }

    public virtual TbClinic? TbClinic { get; set; }

    public virtual ICollection<TbClinicService> TbClinicServices { get; set; } = new List<TbClinicService>();

    public virtual ICollection<TbMedicalRecord> TbMedicalRecords { get; set; } = new List<TbMedicalRecord>();

    public virtual ICollection<TbUser> TbUserSpecialities { get; set; } = new List<TbUser>();

    public virtual ICollection<TbUser> TbUserUserTypes { get; set; } = new List<TbUser>();
}
