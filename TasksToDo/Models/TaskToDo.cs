using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TasksToDo.Models
{
    public class TaskToDo
    {

        public TaskToDo(string description)
        {
            SetDetails(description);
        }
        public int UserId { get; set; }
        public string  Pwd { get; set; }


        [Required]
        [StringLength(500)]
        public string Description { get; private set; }

        public bool IsComplete { get; private set; }



        public void SetDetails(string description)
        {
            Description = description;

        }


        public void MarkComplete()
        {
            IsComplete = true;
        }

        public void MarkIncomplete()
        {
            IsComplete = false;
        }
    }
}
