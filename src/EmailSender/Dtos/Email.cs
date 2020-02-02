namespace EmailSender.Dtos
{
    public class Email
    {
        public string Recipient {get;set;}
        public string Subject {get;set;}
        public string Message {get;set;}
        public string NameOfRecipient {get;set;}
        public Attachment Attachment {get;set;}
    }
}