import io.gatling.core.Predef._
import io.gatling.core.session.Expression
import io.gatling.http.Predef._
import io.gatling.jdbc.Predef._
import scala.concurrent.duration._

class MvpStressTesting extends Simulation {
	val vin_data = csv("MVP.csv").circular

	val httpConf = http 
				    .baseURL("http://dev.api.lightstone.co.za") 

	 val scn = scenario("BasicSimulation") 
	 			.feed(vin_data)
			    .exec(
						http("String body")
	  					.post("/action")
	  					.header("Authorization", "Token ${token}")
	  					.body(StringBody("""{
											  "UserId": "69a69aec-0f9a-4a51-b0b5-e55a203f4603",
											  "ContractId": "b77666d6-bac3-4b9d-9063-b2e92984feaf",
											  "PackageId": "73faca7d-c4d8-4ff8-ac0f-769795218795",
											  "CustomerClientId": "b49114d3-6145-4ad3-9645-65f2fa4ab961",
											  "RequestFields": [
											    {
											      "Name": "License Number",
											      "Value": "${licenseNo}",
											      "Type": "1"      
											    },
											    {
											      "Name": "Vin",
											      "Value": "${vinNo}",
											      "Type": "0"
											    }
											  ]
											}""")).asJSON
	  					.check(status.is(200))
	  					.check(regex("""dataFields""").find.exists)
			    ) 

    setUp( 
    	scn.inject(rampUsers(10) over (10 seconds)
  			).protocols(httpConf)) 
}