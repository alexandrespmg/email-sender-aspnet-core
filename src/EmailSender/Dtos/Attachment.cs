namespace EmailSender.Dtos
{
    public class Attachment
    {
        public string Name {get;set;}
        public string ContentType {get;set;}
        public byte[] File {get;set;}
    }
}