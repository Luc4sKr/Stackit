using Stackit.Domain.Entities;
using Stackit.Domain.DTO;
using Stackit.Domain.IRepositories;
using Stackit.Domain.Enums;
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
                    profile = user.Profile,
                    publications = null
                }).ToList();
        }

        public async Task<UserDTO> FindByUsernameAndPassword(string username, string password)
        {
            var dto = new UserDTO();
            return dto.MapToDTO(await _userRepository.FindByUsernameAndPassword(username, password));
        }

        public async Task<UserDTO> FindById(int id)
        {
            var dto = new UserDTO();
            return dto.MapToDTO(await _userRepository.FindById(id));
        }

        public Task<int> Save(UserDTO entityDTO)
        {
            entityDTO.profile = ProfileEnum.Default;
            return _userRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(UserDTO entityDTO)
        {
            return _userRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _userRepository.FindById(id);
            return await _userRepository.Delete(entity);
        }
    }
}
