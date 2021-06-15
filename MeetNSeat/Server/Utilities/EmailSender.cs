using System;
using System.Threading.Tasks;
using MeetNSeat.Server.Models;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MeetNSeat.Server.Utilities
{
    public static class EmailSender
    {
        public static void ProblemResolved(ProblemModel problem)
        {
            var sendGridClient = new SendGridClient(
                "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");
            
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("owendbgta1@gmail.com", "MeetNSeat");
            sendGridMessage.AddTo(problem.Email);
            sendGridMessage.SetTemplateId("d-fa7d0cfb63dd4e638b3aa626b6043e52");
            sendGridMessage.SetTemplateData(new EmailModel
            {
                Title = problem.Title,
                Description = problem.Description
            });
            
           sendGridClient.SendEmailAsync(sendGridMessage);
        }
        private class EmailModel
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            
            [JsonProperty("description")]
            public string Description { get; set; }
            //
            // [JsonProperty("image")]
            // public string Image { get; set; }
        }
    }
}