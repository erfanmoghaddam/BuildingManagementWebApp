using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingManagementWebApp.Models
{
    public class TenantModel
    {
        private string tenantId;
        private string firstName;
        private string lastName;
        private string address;
        private string email;
        private int phoneNumber;
        private string maritalStatus;
        private string password;
        private DateTime dateOfBirth;

        public string TenantId { get => tenantId; set => tenantId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string Password { get => password; set => password = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}