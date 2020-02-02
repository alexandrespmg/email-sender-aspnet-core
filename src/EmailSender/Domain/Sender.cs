using System.Threading.Tasks;
using EmailSender.Domain.Interfaces;
using EmailSender.Dtos;

namespace EmailSender.Domain
{
    public class Sender : ISender
    {
        public Task SendEmailAsync(Email email)
        {
            throw new System.NotImplementedException();
        }
    }
}