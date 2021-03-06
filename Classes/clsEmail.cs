using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Classes
{
    public class clsEmail
    {
        string destination;
        string sendGridKey;
        public clsEmail(string destination)
        {
            this.destination = destination;
            this.sendGridKey = ConfigurationManager.AppSettings["SendGridApiKey"];
        } 
        public Task SendAccountVerifiedEmail()
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@filmrecommender.co.uk"),
                Subject = "Account confirmed",
                PlainTextContent = "Your email has been successfully validated; you're free to use the service!",
                HtmlContent = "Your email has been successfully validated; you're free to use the service!"
            };

            msg.AddTo(new EmailAddress(destination));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }

        public Task SendNewPasswordConfirmationEmail(DateTime dateTimeReset)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@filmrecommender.co.uk"),
                Subject = "Password reset success",
                PlainTextContent = "Your password has been successfully reset at:   " + dateTimeReset,
                HtmlContent = "Your password has been successfully reset at:    " + dateTimeReset,
            };

            msg.AddTo(new EmailAddress(destination));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }

        public Task SendUserSuspensionEmail(DateTime suspensionEnd)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@filmrecommender.co.uk"),
                Subject = "Account suspension",
                PlainTextContent = "Your account has been suspended for violating our terms and conditions. You can access your account from:   " + suspensionEnd,
                HtmlContent = "Your account has been suspended for violating our terms and conditions. You can access your account from:   " + suspensionEnd
            };

            msg.AddTo(new EmailAddress(destination));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }
        
        public Task SendAccountClosedEmail()
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@filmrecommender.co.uk"),
                Subject = "Account closed",
                PlainTextContent = "Your account with us has been closed.",
                HtmlContent = "Your account with us has been closed."
            };

            msg.AddTo(new EmailAddress(destination));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }

        public Task SendNewStaffMemberStandardNoticeEmail(string privilegeLevel)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@filmrecommender.co.uk"),
                Subject = "Welcome!",
                PlainTextContent = "You have been successfully added as a new staff member with" + privilegeLevel
                + "privileges for the FILM RECOMMENDER system. You now have extended privileges" +
                "in addition to being able to still access your user account.",
                HtmlContent = "You have been successfully added as a new staff member with" + privilegeLevel
                + "privileges for the FILM RECOMMENDER system. You now have extended privileges" +
                "in addition to being able to still access your user account."
            };

            msg.AddTo(new EmailAddress(destination));
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }
    }
}
