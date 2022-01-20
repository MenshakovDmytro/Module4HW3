using System;

namespace Module4HW3.Data.Entities
{
    public class EmployeeProjectEntity
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public int ProjectId { get; set; }
        public ProjectEntity ProjectEntity { get; set; }
    }
}