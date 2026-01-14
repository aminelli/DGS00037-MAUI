
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiAppPassData.Business
{

    public class DataToMessage : ValueChangedMessage<DataMessage> { 
        public DataToMessage(DataMessage value) : base(value) { }
    }


    public class DataFromMessage : ValueChangedMessage<DataMessage>
    {
        public DataFromMessage(DataMessage value) : base(value) { }
    }


    public class DataMessage
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
