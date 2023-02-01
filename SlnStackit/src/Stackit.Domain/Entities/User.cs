using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("publications")]
        public virtual List<Publication> Publications { get; set; }


        public bool IsValidPassword(string password)
        {
            return this.Password == password;
        }

        public void SetPasswordHash()
        {
            
        }
    }
}
