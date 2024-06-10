using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbMedicalRecord
{
    public int Id { get; set; }

    public int RecordTypeId { get; set; }

    public int ClinicId { get; set; }

    public int PatientId { get; set; }

    public string Symptoms { get; set; } = null!;

    public string Diagnoses { get; set; } = null!;

    public string TreatmentPlan { get; set; } = null!;

    public string? Recommendations { get; set; }

    public string? Notes { get; set; }

    public DateTime? NextVisitDate { get; set; }

    public decimal TotalFees { get; set; }

    public decimal PreviousPayment { get; set; }

    public decimal DayPayment { get; set; }

    public decimal RemainingPayment { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbClinic Clinic { get; set; } = null!;

    public virtual TbUser Patient { get; set; } = null!;

    public virtual TbStaticDatum RecordType { get; set; } = null!;

    public virtual ICollection<TbMedicalRecordDoctor> TbMedicalRecordDoctors { get; set; } = new List<TbMedicalRecordDoctor>();

    public virtual ICollection<TbMedicalRecordDocument> TbMedicalRecordDocuments { get; set; } = new List<TbMedicalRecordDocument>();
}
