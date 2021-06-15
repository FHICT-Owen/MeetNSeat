using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MeetNSeat.Server.Utilities
{
    public static class EmailSender
    {
        public static async Task Execute(string email)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("owendbgta1@gmail.com", "MeetNSeat");
            var subject = "Problem is resolved";
            var to = new EmailAddress(email, email);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}