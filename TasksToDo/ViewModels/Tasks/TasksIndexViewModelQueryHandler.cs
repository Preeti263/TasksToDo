using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;
using TasksToDo.Infrastructure.MediatR;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksIndexViewModelQueryHandler : QueryHandlerBase, IRequestHandler<TasksIndexViewModelQuery, TasksIndexViewModel>
    {
        public TasksIndexViewModelQueryHandler(DataContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        public async Task<TasksIndexViewModel> Handle(TasksIndexViewModelQuery request, CancellationToken cancellationToken)
        {


            var model = new TasksIndexViewModel
            {

                Items = await Context.Tasks


                    .OrderBy(x => x.Description)
                    .ProjectTo<TasksIndexViewModel.TaskListEntry>(Mapper.ConfigurationProvider)
                    .ToListAsync()
            };

            return model;
        }
    }
}