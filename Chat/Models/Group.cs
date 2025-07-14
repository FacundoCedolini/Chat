using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<UserGroup> Members { get; set; } = new List<UserGroup>();
        public override string ToString()
        {
            return Name;
        }

    }

}
