using Newtonsoft.Json;

namespace Sendgrid.Webhooks.Events
{
    public enum WebhookEventType
    {
        /// <summary>
        /// Message has been received and is ready to be delivered.
        /// </summary>
        [JsonProperty("processed")]
        Processed,
        /// <summary>
        /// You may see the following drop reasons: Invalid SMTPAPI header, Spam Content (if spam checker app enabled), Unsubscribed Address, Bounced Address, Spam Reporting Address, Invalid, Recipient List over Package Quota
        /// </summary>
        [JsonProperty("dropped")]
        Dropped,
        /// <summary>
        /// Message has been successfully delivered to the receiving server.
        /// </summary>
        [JsonProperty("delivered")]
        Delivered,
        /// <summary>
        /// Recipient’s email server temporarily rejected message.
        /// </summary>
        [JsonProperty("deferred")]
        Deferred,
        /// <summary>
        /// Receiving server could not or would not accept message.
        /// </summary>
        [JsonProperty("bounce")]
        Bounce,
        /// <summary>
        /// Recipient has opened the HTML message.
        /// </summary>
        [JsonProperty("open")]
        Open,
        /// <summary>
        /// Recipient clicked on a link within the message.
        /// </summary>
        [JsonProperty("click")]
        Click,
        /// <summary>
        /// Report	Recipient marked message as spam.
        /// </summary>
        [JsonProperty("spam")]
        Spam,
        /// <summary>
        /// Recipient clicked on message’s subscription management link.
        /// </summary>
        [JsonProperty("unsubscribe")]
        Unsubscribe,
        /// <summary>
        /// Recipient unsubscribed from specific group, by either direct link or updating preferences.
        /// </summary>
        [JsonProperty("group_unsubscribe")]
        GroupUnsubscribe,
        [JsonProperty("group_resubscribe")]
        GroupResubscribe
    }
}