using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Infrastructure.MediatR
{
    public abstract class HandlerBase
    {
        protected HandlerBase(DataContext context)
        {
            Context = context;
        }

        protected DataContext Context { get; private set; }
    }
}