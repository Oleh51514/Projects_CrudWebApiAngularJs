using CrudWebApiAngularJs.Common.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApiAngularJs.Common.DTO
{
    public class AppUserDto : IBaseDto<string>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        //public Guid InvitationToken { get; set; }
    }
}
