using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.GetAll
{
    public interface IGetAllUseCase
    {
        List<Customer> Execute();
    
    }
}
