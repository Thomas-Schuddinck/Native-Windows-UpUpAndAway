using System;

namespace Shared.Models
{
    public class PrivateMessage
    {
        #region Properties
        public int PrivateMessageId { get; set; }
        public Passenger Sender { get; set; }
        public string Message { get; set; }
        public DateTime TimeSend { get; set; } 
        #endregion

        public PrivateMessage(Passenger sender, string message)
        {
            Sender = sender;
            Message = message;
            TimeSend = DateTime.Now;
        }

        public PrivateMessage()
        {
            
        }
    }
}
