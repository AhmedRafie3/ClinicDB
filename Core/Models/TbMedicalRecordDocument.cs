using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbMedicalRecordDocument
{
    public int Id { get; set; }

    public int MedicalRecordId { get; set; }

    public int DocumentIdId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbDocument DocumentId { get; set; } = null!;

    public virtual TbMedicalRecord MedicalRecord { get; set; } = null!;
}
