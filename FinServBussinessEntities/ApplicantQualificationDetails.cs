﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinServBussinessEntities
{
    public class ApplicantQualificationDetails
    {
        public long AutoID { get; set; }
        public System.Guid QualificationID { get; set; }
        public Nullable<System.Guid> ApplicantID { get; set; }
        public Nullable<int> TypeOfQualification { get; set; }
        public string PassingYear { get; set; }
        public string CourseName { get; set; }
        public string UniversityName { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public QualificationTypeMaster _QualificationTypeMaster { get; set; }
    }
}
