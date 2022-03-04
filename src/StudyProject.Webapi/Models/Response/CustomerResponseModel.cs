using System;

namespace StudyProject.Webapi.Models.Response
{
    public class CustomerResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public AddressResponseModel Address { get; private set; }
        public bool Active { get; private set; }

        public CustomerResponseModel(Guid id, string fullName, DateTime birthday, string rg, string cpf, DateTime registerDate, AddressResponseModel address, bool active)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Address = address;
            Active = active;
        }
    }

    public class AddressResponseModel
    {
        public Guid Id { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public AddressResponseModel(Guid id, string zipCode, string street, string number, string complement, string neighborhood, string city, string state)
        {
            Id = id;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }
    }
}
