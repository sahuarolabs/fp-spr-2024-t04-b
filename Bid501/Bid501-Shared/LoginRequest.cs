using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class LoginRequest : Message
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginRequest(string username, string password) : base(Message.Type.LoginRequest)
        {
            Username = username;
            Password = password;
        }
    }
}
