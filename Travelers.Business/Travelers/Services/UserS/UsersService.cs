using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Travelers.Business.Travelers.Models.Users;
using Travelers.entities;
using Travelers.persistance;

namespace Travelers.Business.Travelers.Services.UserS
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }
        public IEnumerable<UsersModel> GetAll()
        {
            var user = usersRepository.GetAll();

            return mapper.Map<IEnumerable<UsersModel>>(user);
        }

        public async Task<UsersModel> GetUserById(Guid idUsers)
        {
            var user = await usersRepository.GetUserById(idUsers);

            return mapper.Map<UsersModel>(user);
        }

        public async Task<UsersModel> Create(CreateUsersModel model)
        {
            var user = this.mapper.Map<User>(model);
            await this.usersRepository.Create(user);
            await this.usersRepository.SaveChanges();
            return mapper.Map<UsersModel>(user);
        }

        public async Task Update(Guid Id, CreateUsersModel model)
        {
            var user = await usersRepository.GetUserById(Id);

            mapper.Map(model, user);

            usersRepository.Update(user);
            await usersRepository.SaveChanges();
        }

        public async Task Delete(Guid idUsers)
        {
            var user = await usersRepository.GetUserById(idUsers);
            usersRepository.Delete(user);
            await usersRepository.SaveChanges();
        }

    }
}
