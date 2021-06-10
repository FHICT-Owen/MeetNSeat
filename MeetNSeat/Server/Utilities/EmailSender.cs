using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Utilities
{
    public static class EmailSender
    {
        public static async Task SendEmail(string emailAddress)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = $"{Environment.GetEnvironmentVariable("HOME")}/Desktop/Emails"
            });

            StringBuilder template = new();
            template.AppendLine("Dear user");
            template.AppendLine("<p>Test</p>");
            template.AppendLine("The MeatNSeat Team");

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            await Email
                .From("koen@kschellingerhout.nl")
                .To(emailAddress)
                .Subject("Your problem has been resolved!")
                .UsingTemplate(template.ToString(), new {})
                .SendAsync();
        }
    }
}