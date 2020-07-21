using System;

namespace API.Models
{
    public class PrivateMessage
    {
        #region Properties
        public int PrivateMessageId { get; set; }
        public Passenger Sender { get; private set; }
        public Passenger Receiver { get; private set; }
        public string Message { get; private set; }
        public DateTime TimeSend { get; private set; } 
        #endregion

        public PrivateMessage(Passenger sender, Passenger receiver, string message)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
            TimeSend = DateTime.Now;
        }

        public PrivateMessage()
        {
            
        }
    }
}
