## Instructions to EventStore server ##

https://github.com/eventstore/eventstore/wiki/Getting-Started-HTTP

*	Download the binaries into a folder (http://geteventstore.com/)
*	Unzip the file and open an admnistrator console
	*	cd to the directory where EventStore is installed
	*	Enter ' EventStore.SingleNode.exe --db ./db --log ./logs ' on the command line
		*	This will start EventStore an will put the database in the path ./db and the logs in ./logs.
		*	Further command line options https://github.com/eventstore/eventstore/wiki/Command-Line-Arguments
	*	EventStore is up and running on your machine http://127.0.0.1:2113/
	*	The console will ask for a username an password
	*	The default credentials are 
		*	Username: admin
		*	Password: changeit

## Instructions to use EventStore client: ##

*	Get EventStroe from Nuget. http://www.nuget.org/packages/EventStore.Client


	