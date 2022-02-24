using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.GetAll
{
    public interface IGetAllUseCase
    {
        void Execute(GetAllRequest request);
    
    }
}
