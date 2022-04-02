using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksIndexViewModelQuery : IRequest<TasksIndexViewModel>
    {

        public int? UserId { get; set; }

    }
}