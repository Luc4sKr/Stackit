using Stackit.Domain.DTO;
using Stackit.Domain.Entities;
using Stackit.Domain.IRepositories;
using Stackit.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Application.Services.SQLServerServices
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepotitory _publicationRepository;

        public PublicationService(IPublicationRepotitory publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }


        public List<PublicationDTO> FindAll()
        {
            return _publicationRepository.FindAll()
                .Select(publication => new PublicationDTO()
                {
                    id = publication.Id,
                    title = publication.Title,
                    content = publication.Content,
                    publicationDate = publication.PublicationDate,
                    userId = publication.UserId,
                    user = new UserDTO()
                    {
                        id = publication.User.Id,
                        username = publication.User.Username,
                        email = publication.User.Email,
                        password = publication.User.Password,
                        profile = publication.User.Profile
                    }
                }).ToList();
        }

        public List<PublicationDTO> FindAllDescending()
        {
            return _publicationRepository.FindAllDescending()
               .Select(publication => new PublicationDTO()
               {
                   id = publication.Id,
                   title = publication.Title,
                   content = publication.Content,
                   publicationDate = publication.PublicationDate,
                   userId = publication.UserId,
                   user = new UserDTO()
                   {
                       id = publication.User.Id,
                       username = publication.User.Username,
                       email = publication.User.Email,
                       password = publication.User.Password,
                       profile = publication.User.Profile
                   }
               }).ToList();
        }

        public List<PublicationDTO> FindAllByUserId(int userId)
        {
            return _publicationRepository.FindAllByUserId(userId)
                .Select(publication => new PublicationDTO()
                {
                    id = publication.Id,
                    title = publication.Title,
                    content = publication.Content,
                    publicationDate = publication.PublicationDate,
                    userId = publication.UserId,
                    user = new UserDTO()
                    {
                        id = publication.User.Id,
                        username = publication.User.Username,
                        email = publication.User.Email,
                        password = publication.User.Password,
                        profile = publication.User.Profile
                    }
                }).ToList();
        }

        public async Task<PublicationDTO> FindById(int id)
        {
            PublicationDTO publicationDTO = new PublicationDTO();
            return publicationDTO.MapToDTO(await _publicationRepository.FindById(id));
        }

        public Task<int> Save(PublicationDTO entityDTO)
        {
            entityDTO.publicationDate = DateTime.Now;
            return _publicationRepository.Save(entityDTO.MapToEntity());
        }

        public Task<int> Update(PublicationDTO entityDTO)
        {
            return _publicationRepository.Update(entityDTO.MapToEntity());
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _publicationRepository.FindById(id);
            return await _publicationRepository.Delete(entity);
        }
    }
}
