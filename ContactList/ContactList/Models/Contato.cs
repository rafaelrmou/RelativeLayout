using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class Contato
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime LastContact { get; set; }

        public string ProfileUrlImage { get; set; }

        public List<string> ListUrlImages { get; set; }

        public string History { get; set; }

    }
}
