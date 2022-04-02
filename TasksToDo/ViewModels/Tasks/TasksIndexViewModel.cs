using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksIndexViewModel : ListViewModelBase<TasksIndexViewModel.TaskListEntry>
    {


        public class TaskListEntry
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool IsComplete { get; set; }

            public int UserId { get; set; }
        }
    }
}