## Instructions to install RabbitMQ server ##

*	Install Erlang (a functional language) since RabbitMQ runs on Erlang virtual runtime from [here](http://www.erlang.org/download.html).
*	Install RabbitMQ server for Windows from [here](http://www.rabbitmq.com/download.html).
*	Install the RabbitMQ Management Plugin (to manage RabbitMQ from a web interface):
	*	Open a command line (with administrative privileges) and point it to [RabbitMQServerInstallationFolder]\sbin
	*	Run "rabbitmq-plugins.bat enable rabbitmq_management"
	*	Restart the service by running the following commands:
		*	rabbitmq-service.bat stop 
		*	rabbitmq-service.bat install 
		*	rabbitmq-service.bat start
	*	Navigate to the web interface in the following address: http://localhost:15672/
	*	The default credentials are 
		*	Username: guest
		*	Password: guest

## Instructions to use RabbitMQ client: ##

*	Get EasyNetQ from Nuget. EasyNetQ is in alpha version and is constantly changing. Have a look [here](https://github.com/mikehadlow/EasyNetQ/wiki/A-Note-on-Versioning) to get more information about the versioning


	