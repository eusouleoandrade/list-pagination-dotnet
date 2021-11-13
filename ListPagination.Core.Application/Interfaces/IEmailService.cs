namespace ListPagination.Core.Application.Interfaces
{
    public interface IEmailService
    {
         void SendEmail(string email, string message);
    }
}