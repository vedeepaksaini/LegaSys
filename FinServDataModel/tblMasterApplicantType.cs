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
    
    public partial class tblMasterApplicantType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasterApplicantType()
        {
            this.tblApplicants = new HashSet<tblApplicant>();
        }
    
        public int ApplicantTypeID { get; set; }
        public string ApplicantType { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblApplicant> tblApplicants { get; set; }
    }
}