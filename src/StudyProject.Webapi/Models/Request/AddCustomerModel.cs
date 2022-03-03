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
        public string Cep { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}
