﻿using System;
using Api.Unit.Tests.Fakes;
using Api.Verfication.Infrastructure.Dto;
using Nancy;
using Nancy.Testing;
using Xunit.Extensions;

namespace Api.Unit.Tests
{
    public class when_sending_drivers_license_request : Specification
    {
        private readonly DefaultNancyBootstrapper _bootstrapper;
        private readonly Browser _browser;
        private BrowserResponse _result;
        private readonly DriversLicenseRequestDto _request;

        public when_sending_drivers_license_request()
        {
            _bootstrapper = new Bootstrapper();
            _browser = new Browser(_bootstrapper);
            _request = new DriversLicenseRequestDto(DriversLicenseScan.GetBase64String(), string.Empty, "jonathan@dnacars.co.za",
                new Guid("5A3DA2CD-6036-440C-B591-58C70B6F2EF2"));
        }

        public override void Observe()
        {
            _result = _browser.Get("/api/verification/driversLicenseVerification/", with =>
            {
                with.HttpRequest();
                with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
                with.Header("Accept", "application/json");
                with.Query("packageId","EB49A837-D9E3-4F2A-8DC9-2CB0BB5D48E2");
                with.Query("packageVersion", "1");
                with.JsonBody(_request);
            });
        }

        [Observation]
        public void then_drivers_verifcation_should_return_ok_when_route_exists()
        {
            _result.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }


        [Observation]
        public void then_drivers_verifcation_should_return_a_valid_result()
        {
            _result.ShouldNotBeNull();
        }
    }


    public class DriversLicenseScan
    {
        public static string GetBase64String()
        {
            //return
            //    "JU1WTDFDQzE2JTAxNDklMTAwMUE1TTAlMSUxMDAxMDU1UzRITVolQ1kxMjQ2NjclSFpaMzYyUyVIYXRjaCBiYWNrIC8gTHVpa3J1ZyVWT0xLU1dBR0VOJUNJVEkgR09MRiVXaGl0ZSAvIFdpdCVBQVZaWloxN1o2VTAyOTg4NiVCU0MyMTM1NDAlMjAxMy0xMS0zMCU=";
            //return
            //    "AZsJRQAAPhokaN6+NLmRE/avM0ST+sH9dJq6BOMTAo+Mt7GToGe/O2SSoq6dsyFjzX0FrmOX6CFHb/KR1vSenx4y1V95bQBPdBykvT/C4E8fRlPoUbRurvW/0eVsQdWoMQRcT73fBsAnxhsTow6DwHp10wJkE1ii8tD/1ahdfAHrQXpaT++34yklYeUjnQR3bDVK1enyNquudYjgxVkuIUTEYSHN61dLTDKX0mdC1UVdEa2HO7UeZL72lCLX5+DezsxUfgYjyTuic5+5RkvYRySoiy/CrI234o3o2cuNFmm8DaXxf1ocBTn914o+9cm5C7wdex62OB2jP2UstwXe1HoaEvv5RK+oyth841obkboS/e3f4/4YKECynxNhe4PCNJVJtPvZqXmvdIbgCcKQbyB2QeUPaHZA9p45g/3Ir/Fksr8HU48n3Wx91DQE7DnZLdyKlrnMmWOkvyxJWYIYjfwX/rXZFRrxU85KnPdTTYQi8halb73ZHlnSYBJhktvugPKOv/N/TOre4c7/xKJD8DhKKlC+Z8Eaie9+YN2AZ6xpoR/Jmw47QogILoIurgKNyQZp0Zkt2RdLxofMZTN8Wj5GOhA83lTRYjf13MaYISahQAZzmvoYUQhrYma2UAWV84h8Mtv6reR+3hvdP6nEI1NVwIlD6V2QtgZVWa3/EF7tEMRzImtB3kApZ9Ge/JBAyOi0xH5HuB2v8t+MXlKD3ncNMau5ZMVeSyS87q2+0l3NgpVOfme2nBK3xRreaRhIGMQAiAIYv1pGiXlv4C0ZspFOsAvGq2074eRQ6lKA4xFSLKHN+JeJUk0FJ5vTaV/YNz0dq9D/5oiqcY5EdaRW4PKTnQunqHdBE+U43vo0+ChcFEfmnPOJbl61mzSBlDsJKA/cAw4B5OSC/ZZg9TZXMN0x/Zsxr4o2Qbb/oghnJboWR7JcGjELr6dvOsi6IwwT";

            return
                "AZsJRQAALEDfbyCGAgDJ7z4oeRI56IEBGJKj1yxUamJ4CVcfzsY5oN4KiceaF76Pu0WGNFIUESbL RFyEwtUoxKNDblMin7JXDaf0Tn3U/DBZ96dEKOVLFL74LaHeynn7fCjF5Ftth6wXPk3Xs1GfQQKS MQePgEvbZ3e4eLOx3CtrluN7CC4VTb8kMqKBYFgk0Z8iC76zHn+mSh2F9nS5UBbQoPLTAC/keGgA YZer8ZmNIikEA9FWZk7vpoqjAmAgRGsjTWOvXT59MlKAmYSXPhLKsRh7BHmOv0egn0OZWTfpNvpO LFbQQ+F2C17ONu+HYLH6SOywqXV8PUEh3R7b47ohl0BSEFWDqQf1NReKTw26n1+1416zrFX8nfaY DsTvZDZFSJABrGIxIWAXg4SbAGaa0bKsPc7n3yqBHfHFWScup5Y/ixoXlafHSIAj4eld9CmOgLw3 bWpYH3YlgnaiVnDgXYgPZpw90rrXTThBRK8HoLCScFeE5k7b3SthmDW2BITnAkepuOQUIkP2puEW QgQLK8kwm/TK3p6a/6gsNMrxpdbjInXrHHs2nhkODlfTkcQgnNUi8CJWoNlNvwhjN43tukhrwzOp 3yoOvoN6sAsj3IaeuE3puJCkxdUoL4U0c9GWSbpIup5Ym47/8NZSK+xDJ6ZLhLUQoDyj/UAdCzIb dixSnVtoP6XuvOsw5E8k6ULRGb1xdnfxnqMmix8iMf4hphh/eYlu65zR0xny+RjGI3mwxSqvWio4 0a4rsQf0xdD4pV5Kv+E/7qvIinPZ8JIhhlsgFsS4v+kpw6X0FLgoi8s4yE8kgQTfYHeMIRzALRL4 S+fExTtUEtNHq7iPDdnkc941brH8NAGxRHkDnVgbAbdHrHanzMkzUv8nF/XhImstiI+E5isph6Fk A1LbZANN+jDmLES5mrplDmqc+UxdVhYW8fA+G31EKNvzVT4m";
        }
    }
}
