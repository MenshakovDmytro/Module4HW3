using System;
using System.Collections.Generic;

namespace Module4HW3.Data.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public OfficeEntity OfficeEntity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public int TitleId { get; set; }
        public TitleEntity TitleEntity { get; set; }
        public ICollection<EmployeeProjectEntity> EmployeeProjectEntities { get; set; }
    }
}