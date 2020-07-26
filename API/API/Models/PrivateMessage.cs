using System;

namespace API.Models
{
    public class PrivateMessage
    {
        #region Properties
        public int PrivateMessageId { get; set; }
        public Passenger Sender { get; set; }
        public Passenger Receiver { get; set; }
        public string Message { get; set; }
        public DateTime TimeSend { get; set; }
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
