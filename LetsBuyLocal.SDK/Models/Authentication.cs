using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBuyLocal.SDK.Models
{
    public class Authentication : BaseEntity
    {
        public override string Id { get; set; }

        public string Email { get; set; }  //Email or FacebookUserId

        public string UserId { get; set; }
        
        public string Password { get; set; }

        public string FacebookUserId { get; set; }
    }
}
