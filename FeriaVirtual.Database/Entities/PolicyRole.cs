using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Database.Entities
{
    public class PolicyRole
    {
        public int PolicyId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Policy Policy { get; set; }
        public Role Role { get; set; }
    }
}
