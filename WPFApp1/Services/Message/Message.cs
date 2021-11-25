namespace WPFApp1.Services.Message
{
    public class Message : IMessage
    {
        public int Guid { get; set; }
        public Message(int guid)
        {
            Guid = guid;
        }
    }
}
