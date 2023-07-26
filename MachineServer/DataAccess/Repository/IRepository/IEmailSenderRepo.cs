using MachineServer.Base;

namespace MachineServer.DataAccess.Repository.IRepository;

public interface IEmailSenderRepo
{
    Task SendEmailAsync(RecipientEmail recipient);
}