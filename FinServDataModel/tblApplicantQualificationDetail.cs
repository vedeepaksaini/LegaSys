//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinServDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblApplicantQualificationDetail
    {
        public long AutoID { get; set; }
        public System.Guid QualificationID { get; set; }
        public System.Guid ApplicantID { get; set; }
        public string PassingYear { get; set; }
        public string CourseName { get; set; }
        public string UniversityName { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public int TypeOfQualification { get; set; }
    
        public virtual tblMasterTypeOfQualification tblMasterTypeOfQualification { get; set; }
        public virtual tblApplicant tblApplicant { get; set; }
    }
}
