using Stackit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.DTO
{
    public class PublicationDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime? publicationDate { get; set; }
        public int userId { get; set; }
        public virtual UserDTO? user { get; set; }
    
        public Publication MapToEntity()
        {
            return new Publication
            {
                Id = id,
                Title = title,
                Content = content,
                PublicationDate = publicationDate,
                UserId = userId
            };
        }

        public PublicationDTO MapToDTO(Publication publication)
        {
            return new PublicationDTO
            {
                id = publication.Id,
                title = publication.Title,
                content = publication.Content,
                publicationDate = publication.PublicationDate,
                userId = publication.UserId
            };
        }
    }
}
