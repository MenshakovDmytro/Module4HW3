using System;
using System.Collections.Generic;

namespace Module4HW3.Data.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public ICollection<EmployeeProjectEntity> EmployeeProjectEntities { get; set; }
    }
}