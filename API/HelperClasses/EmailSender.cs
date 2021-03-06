using MessageBrokerPublisher;
using MessageBrokerPublisher.Models;
using MessageBrokerPublisher.Services;

namespace API.HelperClasses
{
    /// <summary>
    /// EmailSender Interface
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="recipient">The email address of the recipient</param>
        /// <param name="textContent">The text content of the email</param>
        /// <param name="htmlContent">The HTML content of the email</param>
        public void Send(string recipient, string textContent, string htmlContent);
    }

    /// <summary>
    /// Class which is responsible for sending emails
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private ITaskPublisher notificationSender;

        /// <summary>
        ///  Constructor to instantiate the email sender
        /// </summary>
        public EmailSender(ITaskPublisher notificationSender)
        {
            this.notificationSender = notificationSender;
        }

        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="recipient">The email address of the recipient</param>
        /// <param name="textContent">The text content of the email</param>
        /// <param name="htmlContent">The HTML content of the email</param>
        public void Send(string recipient, string textContent, string htmlContent = null)
        {
            EmailNotificationRegister emailNotification = new EmailNotificationRegister(recipient, textContent, htmlContent);
            notificationSender.RegisterTask(Newtonsoft.Json.JsonConvert.SerializeObject(emailNotification), Subject.EMAIL);
        }
    }
}
