using Stackit.Domain.Entities;
using Stackit.Domain.DTO;
using Stackit.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stackit.Domain.IServices;

namespace Stackit.Application.Services.SQLServerServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public List<UserDTO> FindAll()
        {
            return _userRepository.FindAll()
                .Select(user => new UserDTO()
                {
                    id = user.Id,
                    username = user.Username,
                    email = user.Email,
                    password = user.Password,
                    profile = user.Profile
                }).ToList();
        }

        public async Task<UserDTO> FindByUsernameAndPassword(string username, string password)
        {
            var dto = new UserDTO();
            return dto.MapToDTO(await _userRepository.FindByUsernameAndPassword(username, password));
        }

        public Task<UserDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(UserDTO entity)
        {
            return _userRepository.Save(entity.MapToEntity());
        }

        public Task<int> Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
