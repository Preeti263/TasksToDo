using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.ViewModels.Tasks;

namespace TasksToDo.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private const string NotificationMessageKey = "NotificationMessage";

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(TasksIndexViewModelQuery query)
        {
            var model = await _mediator.Send(query);
            model.NotificationMessage = TempData[NotificationMessageKey] as string;
            return View(model);
        }
    }
}