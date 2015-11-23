import io.gatling.core.Predef._
import io.gatling.core.session.Expression
import io.gatling.http.Predef._
import io.gatling.jdbc.Predef._
import scala.concurrent.duration._

class MvpStressTestingProd extends Simulation {
	val vin_data = csv("MVP.csv").circular

	val httpConf = http 
				    .baseURL("http://prod.api.lightstone.co.za") 

	 val scn = scenario("BasicSimulation") 
	 			.feed(vin_data)
			    .exec(
						http("String body")
	  					.post("/action")	  					
	  					.header("Authorization", "Token bGl2ZTJzeXN0ZW1AbGlnaHRzdG9uZWF1dG8uY28uemENClN1cGVyVXNlcg0KNjM1ODM1OTIzOTQzMTc1NTQ4:XdNWOhekpvO73ZEdUb72ZrGvnJJPq42nHCfKkBOBUd8=")
	  					.body(StringBody("""{
											  "UserId": "c699299e-525b-4efc-8e11-819909429d10",
											  "ContractId": "9739ce2e-281a-4bc2-aef2-9be0ba474e87",
											  "PackageId": "893fd02f-3121-4375-b626-8752558381a0",
											  "CustomerClientId": "cebaace3-4d4b-474c-b7b7-5366f7b4c8c5",
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
			    .pause(0)

    setUp( 
    	scn.inject(rampUsers(40) over (60 seconds)
  			).protocols(httpConf)) 
}