# Billing Component #

## Billing API ##
### IIS ###

*	Create a website called dev.billing.lightstone.api and point it the to API folder in the app folder
*	Ensure the application pool for the website is .NET 4.0
*	Update the bindings on the website to listen for the dev.billing.lightstone.api host header

### HOSTS file ###

*	Add the following entry to your HOSTS file
	*	127.0.0.1	dev.billing.lightstone.api


## Billing connector ##

*	Install the connector via NuGet (still to come)
*	Add the following keys to the application settings
	*	**billing/url**, this key is the base URL for the billing API. On your local machine it will be *http://dev.billing.lightstone.api/*
		*	Make sure the URL ends with a /
	*	billing/apiKey, at this point any value will do
*	To use the connector either inject via the IConnectToBilling interface or instantiate via the public DefaultBillingConnector(IBillingConnectorConfiguration configuration) constructor 
 
