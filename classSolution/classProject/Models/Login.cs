using System;
using System.Collections.Generic;

namespace classProject.Models
{
    public partial class Login
    {
        public Login()
        {
            Expeditions = new HashSet<Expedition>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Expedition> Expeditions { get; set; }
    }
}
