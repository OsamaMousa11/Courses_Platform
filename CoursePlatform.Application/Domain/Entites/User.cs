using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Domain.Entites
{
    public class User:BaseEntity
    {
      
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
      



    }
}
