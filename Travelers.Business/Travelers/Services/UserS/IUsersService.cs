﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Users;

namespace Travelers.Business.Travelers.Services.UserS
{
    public interface IUsersService
    {
        IEnumerable<UsersModel> GetAll();

        Task<UsersModel> GetUserById(Guid idUsers);

        Task<UsersModel> Create(CreateUsersModel model);

        Task Delete(Guid idUsers);

        Task Update(Guid idUsers, CreateUsersModel model);
    }
}