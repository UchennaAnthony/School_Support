//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolSupport.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class STUDENT
    {
        public STUDENT()
        {
            this.STUDENT_LEVEL = new HashSet<STUDENT_LEVEL>();
            this.TICKET = new HashSet<TICKET>();
        }
    
        public long Person_Id { get; set; }
        public string Application_Form_Number { get; set; }
        public Nullable<long> Student_Number { get; set; }
        public string Matric_Number { get; set; }
        public string School_Contact_Address { get; set; }
        public Nullable<int> Student_Category_Id { get; set; }
        public Nullable<int> School_Id { get; set; }
    
        public virtual PERSON PERSON { get; set; }
        public virtual SCHOOL SCHOOL { get; set; }
        public virtual ICollection<STUDENT_LEVEL> STUDENT_LEVEL { get; set; }
        public virtual STUDENT_CATEGORY STUDENT_CATEGORY { get; set; }
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}