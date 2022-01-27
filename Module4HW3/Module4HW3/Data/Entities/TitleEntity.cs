using System.Collections.Generic;

namespace Module4HW3.Data.Entities
{
    public class TitleEntity
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeEntity> EmployeeEntities { get; set; } = new List<EmployeeEntity>();
    }
}