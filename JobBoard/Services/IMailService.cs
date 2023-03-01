using JobBoard.ViewModels;

namespace JobBoard.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestVM mailRequest);
    }
}
