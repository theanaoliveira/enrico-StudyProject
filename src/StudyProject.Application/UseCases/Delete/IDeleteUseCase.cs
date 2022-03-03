using System;
using System.Collections.Generic;
using System.Text;

namespace StudyProject.Application.UseCases.Delete
{
    public interface IDeleteUseCase
    {
        bool Execute(DeleteRequest request);
    }
}
