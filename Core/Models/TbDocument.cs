using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbDocument
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string DocumentKey { get; set; } = null!;

    public string? Annotation { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbUser Patient { get; set; } = null!;

    public virtual ICollection<TbChatMessage> TbChatMessages { get; set; } = new List<TbChatMessage>();

    public virtual ICollection<TbMedicalRecordDocument> TbMedicalRecordDocuments { get; set; } = new List<TbMedicalRecordDocument>();
}
