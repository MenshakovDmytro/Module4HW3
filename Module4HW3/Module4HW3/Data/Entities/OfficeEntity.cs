using System.Collections.Generic;

namespace Module4HW3.Data.Entities
{
    public class OfficeEntity
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public ICollection<EmployeeEntity> EmployeeEntities { get; set; } = new List<EmployeeEntity>();
    }
}