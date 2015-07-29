## Overview ##
*	An extension from EasyNetQ.Hosepipe
*	https://github.com/EasyNetQ/EasyNetQ/wiki/Re-Submitting-Error-Messages-With-EasyNetQ.Hosepipe
*	Modified to run as a service and to loop through a a list of configurations to re-process errors on error message queues
*	Some functionality that was not required has been removed; while additional functions to suit the requirements of LS Dataplatform project have been added

## Infrastructure ##
*	Install RabbitMQ on your local machine. Following instructions from [https://github.com/EasyNetQ/EasyNetQ/wiki/Quick-Start](https://github.com/EasyNetQ/EasyNetQ/wiki/Quick-Start "EasyNetQ Quick Start")
