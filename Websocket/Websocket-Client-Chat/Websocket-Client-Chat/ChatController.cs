using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Text.Json;

namespace Websocket_Client_Chat
{
    class ChatController
    {
        private string name;
        private WebSocket ws;
        
        private RoomUserMsg roomUserMsg = new RoomUserMsg();
        


        public event Message MessageReceived;

        public ChatController(string name)
        {
            this.name = name;
            roomUserMsg.user = new User();
            roomUserMsg.room = new ChatRoom();
            roomUserMsg.user.Username = name;
            // Connects to the server
            ws = new WebSocket("ws://127.0.0.1:8001/chat");
            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.Connect();
            
        }

        // Handles when a new message is entered by the user
        public bool MessageEntered(string message)
        {

            string jsoned = JsonSerializer.Serialize(roomUserMsg);
            
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                
                ws.Send(jsoned);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Makes sure to close the websocket when the controller is destructed
        ~ChatController()
        {
            ws.Close();
        }
    }
}
