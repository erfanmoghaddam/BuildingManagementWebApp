using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingManagementWebApp.Models
{
    public class EmployeeModel
    {
        private string employeeId;
        private string firstName;
        private string lastName;
        private string email;
        private int phoneNumber;
        private string jobTitle;
        private DateTime dateOfBirth;
        private string password;

        public string EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Password { get => password; set => password = value; }
    }
}