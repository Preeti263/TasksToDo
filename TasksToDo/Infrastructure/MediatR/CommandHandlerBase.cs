using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Infrastructure.MediatR
{
    public abstract class CommandHandlerBase : HandlerBase
    {
        protected CommandHandlerBase(DataContext context)
            : base(context)
        {
        }
    }
}