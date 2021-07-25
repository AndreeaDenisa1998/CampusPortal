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
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository _usersRepository, IMapper _mapper)
        {
            this._usersRepository = _usersRepository;
            this._mapper = _mapper;
        }
        public IEnumerable<UsersModel> GetAll()
        {
            var user = _usersRepository.GetAll();

            return _mapper.Map<IEnumerable<UsersModel>>(user);
        }

        public async Task<UsersModel> GetUserById(Guid idUsers)
        {
            var user = await _usersRepository.GetUserById(idUsers);

            return _mapper.Map<UsersModel>(user);
        }

        public async Task<UsersModel> Create(CreateUsersModel model)
        {
            var user = this._mapper.Map<User>(model);
            await this._usersRepository.Create(user);
            await this._usersRepository.SaveChanges();
            return _mapper.Map<UsersModel>(user);
        }

        public async Task Update(Guid IdUsers, CreateUsersModel model)
        {
            var user = await _usersRepository.GetUserById(IdUsers);

            _mapper.Map(model, user);

            _usersRepository.Update(user);
            await _usersRepository.SaveChanges();
        }

        public async Task Delete(Guid idUsers)
        {
            var user = await _usersRepository.GetUserById(idUsers);
            _usersRepository.Delete(user);
            await _usersRepository.SaveChanges();
        }

    }
}
