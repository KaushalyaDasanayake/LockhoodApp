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
    
    public partial class EmployeeTask
    {
        public int taskID { get; set; }
        public int worktaskID { get; set; }
        public string empName { get; set; }
        public System.TimeSpan allocatedHours { get; set; }
    
        public virtual WorkTask WorkTask { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
