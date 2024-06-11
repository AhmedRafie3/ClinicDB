using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbUser
{
    public int Id { get; set; }

    public int? OrganizationId { get; set; }

    public int UserTypeId { get; set; }

    public int? SpecialityId { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ImageKey { get; set; }

    public bool ActivationStatus { get; set; }

    public bool EnableCrossEdit { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbOrganization? Organization { get; set; }

    public virtual TbStaticDatum? Speciality { get; set; }

    public virtual ICollection<TbChatSessionUser> TbChatSessionUserUser1s { get; set; } = new List<TbChatSessionUser>();

    public virtual ICollection<TbChatSessionUser> TbChatSessionUserUser2s { get; set; } = new List<TbChatSessionUser>();

    public virtual ICollection<TbClinicStaff> TbClinicStaffs { get; set; } = new List<TbClinicStaff>();

    public virtual ICollection<TbDocument> TbDocuments { get; set; } = new List<TbDocument>();

    public virtual ICollection<TbMedicalRecordDoctor> TbMedicalRecordDoctors { get; set; } = new List<TbMedicalRecordDoctor>();

    public virtual ICollection<TbMedicalRecord> TbMedicalRecords { get; set; } = new List<TbMedicalRecord>();

    public virtual ICollection<TbReservation> TbReservations { get; set; } = new List<TbReservation>();

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();

    public virtual TbStaticDatum UserType { get; set; } = null!;
}
