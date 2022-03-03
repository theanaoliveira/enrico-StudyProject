using System;
using System.ComponentModel.DataAnnotations;

namespace StudyProject.Webapi.Models.Request
{
    public class UpdateCustomerModel : AddCustomerModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
