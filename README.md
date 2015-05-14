[![Build Status](https://travis-ci.org/mirajavora/sendgrid-webhooks.png)](https://travis-ci.org/mirajavora/sendgrid-webhooks)

# Sendgrid Webhooks
A library to parse event webhooks from Sendgrid. Contains Parser and a set of strongly typed DTOs. It supports all available webhook events, unique arguments and categories.

# Download via NuGet
[TODO]

# Usage

Declare WebhookParser and call ParseEvents. This takes in string as JSON received from the HTTP POST callback.

	var parser = new WebhookParser();
	var events = parser.ParseEvents(json);

The parser returns a polymorphic IList of WebhookEventBase, where each item is a strongly typed Webhook Event.

	var webhookEvent = events[0];
	Console.WriteLine(event.EventType


*Example JSON*

	[
	  {
	    "email": "john.doe@sendgrid.com",
	    "timestamp": 1337197600,
	    "smtp-id": "<4FB4041F.6080505@sendgrid.com>",
	    "event": "processed"
	  },
	  {
	    "email": "john.doe@sendgrid.com",
	    "timestamp": 1337966815,
	    "category": "newuser",
	    "event": "click",
	    "url": "https://sendgrid.com"
	  }
	]


# Unique Arguments

Is the ability to pass in additional arguments along with the message. This is mainly to add meta-data to the message. [Find out more in the documentation](https://sendgrid.com/docs/API_Reference/SMTP_API/unique_arguments.html).

	{
	  "unique_args": {
	    "customerAccountNumber": "55555",
	    "activationAttempt": "1",
	    "New Argument 1": "New Value 1",
	    "New Argument 2": "New Value 2",
	    "New Argument 3": "New Value 3",
	    "New Argument 4": "New Value 4"
	  }
	}

The WebhookParser looks at each unique property within the JSON and adds it to a UniqueParameters dictionary. 

	var value = event.UniqueParameters["customerAccountNumber"];
	Console.WriteLine(value); // outputs 55555

# Overriding JsonConverter
The parser supports a custom JsonConverter as an argument. This theoretically allows you to write your own custom DTOs, as long as they are still based on the WebhookEventBase.