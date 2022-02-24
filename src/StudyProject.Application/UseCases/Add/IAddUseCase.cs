using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.Add
{
    public interface IAddUseCase
    {
        void Execute(AddRequest request);
    }
}
