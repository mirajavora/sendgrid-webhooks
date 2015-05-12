using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public enum WebhookEventType
    {
        /// <summary>
        /// Message has been received and is ready to be delivered.
        /// </summary>
        Processed,
        /// <summary>
        /// You may see the following drop reasons: Invalid SMTPAPI header, Spam Content (if spam checker app enabled), Unsubscribed Address, Bounced Address, Spam Reporting Address, Invalid, Recipient List over Package Quota
        /// </summary>
        Dropped,
        /// <summary>
        /// Message has been successfully delivered to the receiving server.
        /// </summary>
        Delivered,
        /// <summary>
        /// Recipient’s email server temporarily rejected message.
        /// </summary>
        Deferred,
        /// <summary>
        /// Receiving server could not or would not accept message.
        /// </summary>
        Bounce,
        /// <summary>
        /// Recipient has opened the HTML message.
        /// </summary>
        Open,
        /// <summary>
        /// Recipient clicked on a link within the message.
        /// </summary>
        Click,
        /// <summary>
        /// Report	Recipient marked message as spam.
        /// </summary>
        SpamReport,
        /// <summary>
        /// Recipient clicked on message’s subscription management link.
        /// </summary>
        Unsubscribe,
        /// <summary>
        /// Recipient unsubscribed from specific group, by either direct link or updating preferences.
        /// </summary>
        Group_Unsubscribe,
        Group_Resubscribe
    }
}