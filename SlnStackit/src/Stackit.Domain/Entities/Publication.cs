using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.Entities
{
    [Table("Publications")]
    public class Publication
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }
        
        [Column("publicationDate")]        
        public DateTime PublicationDate { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
