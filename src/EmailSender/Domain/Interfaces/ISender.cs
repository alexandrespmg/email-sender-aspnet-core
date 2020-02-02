using System.Threading.Tasks;
using EmailSender.Dtos;

namespace EmailSender.Domain.Interfaces
{
    public interface ISender
    {
        Task SendEmailAsync(Email email);
    }
}