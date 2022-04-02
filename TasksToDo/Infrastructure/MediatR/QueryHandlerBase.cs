using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Infrastructure.MediatR
{
    public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(DataContext context, IMapper mapper)
            : base(context)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }
    }
}