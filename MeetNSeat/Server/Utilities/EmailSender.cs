using System.Net.Mail;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Smtp;

namespace MeetNSeat.Server.Utilities
{
    public static class EmailSender
    {
        public static async Task SendEmail(string emailAddress)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = true
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("")
                .To(emailAddress)
                .Subject("Your problem has been resolved!")
                .Body("The problem you reported has been resolved.")
                .SendAsync();
        }
    }
}