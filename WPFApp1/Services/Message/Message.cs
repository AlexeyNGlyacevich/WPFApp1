using System;

namespace WPFApp1.Services.Message
{
    public class Message : IMessage
    {
        public int Guid { get; set; }

        readonly Func<string, bool> deleg = s => s.Contains("abc");
        public Message(int guid)
        {
            Guid = guid;
            
        }
        public void Delegate(string str)
        {
            deleg.Invoke(str);
        }
    }
}
