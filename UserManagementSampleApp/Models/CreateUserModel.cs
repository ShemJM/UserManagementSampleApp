using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSampleApp.Models
{
    public class CreateUserModel
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
