using MimeKit;

namespace EmailSender.Dtos
{
    public class Attachment
    {
        public string Name {get;set;}
        public ContentType ContentType {get;set;}
        public byte[] File {get;set;}
    }
}