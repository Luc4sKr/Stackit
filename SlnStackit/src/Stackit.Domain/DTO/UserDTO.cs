using Stackit.Domain.Entities;
using Stackit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public ProfileEnum? profile { get; set; }
        public virtual List<PublicationDTO> publications { get; set; }
    
        public User MapToEntity()
        {
            return new User
            {
                Id = id,
                Username = username,
                Email = email,
                Password = password,
                Profile = profile
            };
        }

        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                id = user.Id,
                username = user.Username,
                email = user.Email,
                password = user.Password,
                profile = user.Profile
            };
        }
    }
}
