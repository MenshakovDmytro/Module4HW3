using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module4HW3.Data.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public ICollection<EmployeeProjectEntity> EmployeeProjectEntities { get; set; } = new List<EmployeeProjectEntity>();
        public ClientEntity ClientEntity { get; set; }
        public int ClientId { get; set; }
    }
}