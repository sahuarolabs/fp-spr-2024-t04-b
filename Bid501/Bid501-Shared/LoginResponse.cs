using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class LoginResponse : Message
    {
        public bool Success { get; set; }

        public LoginResponse(bool success) : base(Message.Type.LoginResponse)
        {
            Success = success;
        }
    }
}
