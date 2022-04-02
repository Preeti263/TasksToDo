using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Models;
using static TasksToDo.ViewModels.Tasks.TasksIndexViewModel;

namespace TasksToDo.Mapper
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<TaskToDo, TaskListEntry>();
           
        }
    }
}