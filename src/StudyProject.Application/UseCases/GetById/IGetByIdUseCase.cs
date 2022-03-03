using StudyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Customer Execute(GetByIdRequest request);
        
    }
}
