using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels
{
    public abstract class ListViewModelBase<T>
    {
        public IEnumerable<T> Items { get; set; }

        public string NotificationMessage { get; set; }

        public bool ShowNotificationMessage => !string.IsNullOrEmpty(NotificationMessage);
    }
}