using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websocket_Client_Chat
{
    public class RoomUserMsg
    {

        public User user { get; set; }
        public ChatRoom room { get; set; }
        public string message { get; set; }
        public RoomUserMsg()
        {
            user = new User();
            room = new ChatRoom();
            message = "";

        }
        public override string ToString()
        {
            return $"{user.Username}: {message}";
        }
    }
}
