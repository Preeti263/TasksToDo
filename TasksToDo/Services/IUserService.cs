using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Models;

namespace TasksToDo.Services
{
    public interface IUserService
    {
        Task<(bool, Users)> ValidateUserCredentialsAsync(string username, string password);
    }
}