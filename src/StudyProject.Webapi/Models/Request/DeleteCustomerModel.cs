using System;
using System.ComponentModel.DataAnnotations;

namespace StudyProject.Webapi.Models.Request
{
    public class DeleteCustomerModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
