using System;
using System.Collections.Generic;

namespace Module4HW3.Data.Entities
{
    public class ClientEntity
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public ICollection<ProjectEntity> ProjectEntities { get; set; }
    }
}