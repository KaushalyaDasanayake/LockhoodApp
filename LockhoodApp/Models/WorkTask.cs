//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LockhoodApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkTask()
        {
            this.EmployeeTasks = new HashSet<EmployeeTask>();
        }
    
        public int ID { get; set; }
        public Nullable<int> salesID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public System.DateTime ExpectedDate { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
        public virtual OrderSale OrderSale { get; set; }
        public virtual WorkTask WorkTask1 { get; set; }
        public virtual WorkTask WorkTask2 { get; set; }
    }
}
