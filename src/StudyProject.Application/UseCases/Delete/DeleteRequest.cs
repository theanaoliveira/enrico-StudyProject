using StudyProject.Domain;
using System;

namespace StudyProject.Application.UseCases.Delete
{
    public class DeleteRequest
    {
        public Guid Id { get; private set; }
        public Customer Customer { get; set; }

        public DeleteRequest(Guid id)
        {
            Id = id;
        }
    }
}