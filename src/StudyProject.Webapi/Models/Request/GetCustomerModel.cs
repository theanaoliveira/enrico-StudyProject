using System;
using System.ComponentModel.DataAnnotations;

namespace StudyProject.Webapi.Models.Request
{
    public class GetCustomerModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
