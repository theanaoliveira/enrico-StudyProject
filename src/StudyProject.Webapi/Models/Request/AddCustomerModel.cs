using System;
using System.ComponentModel.DataAnnotations;

namespace StudyProject.Webapi.Models.Request
{
    public class AddCustomerModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Rg { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        public string Complement { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
    }
}
