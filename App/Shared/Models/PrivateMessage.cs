using System;

namespace Shared.Models
{
    public class PrivateMessage
    {
        #region Properties
        public int PrivateMessageId { get; set; }
        public Passenger Sender { get; private set; }
        public string Message { get; private set; }
        public DateTime TimeSend { get; private set; } 
        #endregion

        public PrivateMessage(Passenger sender, string message)
        {
            Sender = sender;
            Message = message;
            TimeSend = DateTime.Now;
        }
    }
}
