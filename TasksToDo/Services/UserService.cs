using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Models;

namespace TasksToDo.Services
{
    public class UserService : IUserService
    {
        private readonly IDictionary<string, Users> _users;

        public UserService(IDictionary<string, Users> users) => _users = users;

        public Task<(bool, Users)> ValidateUserCredentialsAsync(string username, string password)
        {
            var isValid = _users.ContainsKey(username) &&
                          string.Equals(_users[username].Pwd, password, StringComparison.Ordinal);
            var result = (isValid, isValid ? _users[username] : null);
            return Task.FromResult(result);
        }
    }
}