using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.GetById
{
    public class GetByIdRequest
    {
        public Guid Id { get; private set; }

        public GetByIdRequest(Guid id)
        {
            Id = id;           
        }
    }
}
