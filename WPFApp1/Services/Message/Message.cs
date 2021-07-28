using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp1.Services.Message
{
    public class Message : IMessage
    {
        public Message(int guid)
        {
            Guid = guid;
        }
        public int Guid { get; set; }


    }
}
