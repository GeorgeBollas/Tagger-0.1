namespace Tagger.Services
{
    public class ResponseMessage
    {
        public const int ExceptionMessageId = 9999999;

        public int MessageId { get; set; }
        public string Message { get; set; }

        public MessageLevel ResultLevel { get; set; }
    }

    public enum MessageLevel
    {
        Success = 0,
        Info = 1,
        Warning = 2,
        NonCritical = 3,
        Critical = 4
    }
}