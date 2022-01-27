using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module4HW3.Data.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public OfficeEntity OfficeEntity { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTimeOffset HiredDate { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public int TitleId { get; set; }
        public TitleEntity TitleEntity { get; set; }
        public ICollection<EmployeeProjectEntity> EmployeeProjectEntities { get; set; } = new List<EmployeeProjectEntity>();
    }
}