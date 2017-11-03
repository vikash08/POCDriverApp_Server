using Microsoft.Azure.WebJobs;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POCDriverAppWebJobMesToEconnect
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static async  void ProcessQueueMessage([ServiceBusTrigger("goodsevents")] string message, TextWriter log)
        {
            log.WriteLine(message);
            //try
            //{ 
            string url = "http://qec4lb.posten.no:9009/T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS ";
            using (var client = new HttpClient())
            {
                //  client.BaseAddress = new Uri("https://posten-test2.servicebus.windows.net/posten-test2");
                client.BaseAddress = new Uri(url);
                // client.BaseAddress = new Uri("https://validategoods.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                
                HttpContent stringContent = new StringContent(message, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", stringContent);

                //log.WriteLine(response.IsSuccessStatusCode);
             
            }
                     
            log.WriteLine("completed");
        }



        //public static async Task<bool> SendMessagetoEconnect(string test)
        //{
        //    //string url = "https://posten-test2.servicebus.windows.net/posten-test2/T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS";
        //    // string url = "https://posten-test2.servicebus.windows.net/posten-test2/T50051_GoodsEventFromScanningApp";
        //    string url = "http://qec4lb.posten.no:9009/T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS ";

        //    //string addon = "T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS";
        //    //ViewData["ADDitionalURL"] = addon;

        //    // string test = "{  \"consignmentnumber\" : \"string\",  \"consignmentitemnumber\" : \"string\",  \"deliverycode\" : \"string\",  \"tripid\" : \"string\",  \"stopid\" : \"string\",  \"actiontype\" : \"string\",  \"eventcode\" : \"string\",  \"externaltripid\" : \"string\",  \"routeid\" : \"string\",  \"stopsequenceno\" : 3,  \"combinationtripinfo\" : {    \"externaltripid\" : \"string\",    \"routeid\" : \"string\",    \"stopsequenceno\" : 3  },  \"loadcarrierid\" : \"string\",  \"powerunitid\" : \"string\",  \"orgunitidforaction\" : \"string\",  \"locationid\" : \"string\",  \"getevents\" : \"string\",  \"getvaspayment\" : false,  \"getextended\" : true,  \"getpackagetype\" : true,  \"getallitems\" : true,  \"validationtype\" : \"consignment\",  \"validationlevel\" : \"plan\",  \"logginginformation\" : {    \"logonname\" : \"string\",    \"systemcode\" : \"string\",    \"languagecode\" : \"string\",    \"companycode\" : \"string\",    \"countrycode\" : \"string\",    \"orgunitid\" : \"string\",    \"userrole\" : \"string\",    \"processname\" : \"string\",    \"subprocessname\" : \"string\",    \"subprocessversion\" : \"string\",    \"interfaceversion\" : \"string\",    \"invocationtime\" : \"2006-08-19t19:27:14+02:00\",    \"messageid\" : \"string\"  },  \"customerid\" : \"string\",  \"ordernumber\" : \"string\",  \"tmsaffiliationid\" : \"string\"}";

        //  //  string test = "{\"UserInformation\" : { \"UserLogonId\" :\"660047\", \"FirstName\" : \"Sameer\",\"LastName\" : \"Test\",\"UserOrgUnitId\" : \"736402\", \"PhoneNumber\" : \"96987834\" }, \"EventInformation\" : { \"EventCode\" : \"I\", \"EventTime\" : \"2016-07-07T17:11:25.064+02:00\", \"Consignment\" : [ { \"EventType\" : \"ConsignmentItemEvent\", \"ConsignmentNumber\" : \"70300490028029938\",\"ConsignmentItem\" : [ { \"ConsignmentItemNumber\" : \"TT100050000NO\" } ] } ],\"Signature\" : {\"SignatureId\" : \"751B5D46-12A1-48FE-8C3E-045CEF109764\",\"Signature\" : \"c2Nhbm5pbmdBcHA=\",\"RecipientName\" : \"Linn Haviken\",\"SignatureTime\" : \"2016-07-15T10:43:20.942+02:00\"}}, \"LocationInformation\" : { \"EventOrgUnitId\" : \"101278\", \"EventPostalCode\" : \"3003\", \"EventCountryCode\" : \"NO\", \"EventCompanyCode\" : \"POS\" }, \"CaptureEquipment\" : { \"CaptureEquipmentId\" : \"OT20502\", \"CaptureEquipmentType\" : \"PDA\" }, \"OperationInformation\" : { \"PlanId\" : \"string\", \"PhysicalLoadCarrier\" : \"string\", \"OperationOriginSystem\" : \"string\", \"PowerUnitId\" : \"string\", \"RouteId\" : \"2001\" }, \"LoggingInformation\" : { \"TimeFromClient\" : \"2014-06-27T21:41:15+02:00\", \"TimeToIntegrationServer\" : \"2017-08-17T07:44:20\", \"ProcessName\" : \"Loading\", \"SubProcessName\" : \"LoadDistribTruck\", \"SubProcessVersion\" : \"6.1.0.195\" }, \"TMSAffiliationId\" : \"NO_TMS\" } ";



        //    return await ReturnfromEconnectAsync(url, test);
        //    //ViewData["Response"] = x;

        //    //r.Message1 = x;
        //    // ModelState["Message1"].RawValue = x;
        //}





        //public static async Task<bool> ReturnfromEconnectAsync(string url, string test)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        //  client.BaseAddress = new Uri("https://posten-test2.servicebus.windows.net/posten-test2");
        //        client.BaseAddress = new Uri(url);
        //        // client.BaseAddress = new Uri("https://validategoods.azurewebsites.net");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //string test = "{  \"ConsignmentNumber\" : \"string\",  \"ConsignmentItemNumber\" : \"string\",  \"DeliveryCode\" : \"string\",  \"TripId\" : \"string\",  \"StopId\" : \"string\",  \"ActionType\" : \"string\",  \"EventCode\" : \"string\",  \"ExternalTripId\" : \"string\",  \"RouteId\" : \"string\",  \"StopSequenceNo\" : 3,  \"CombinationTripInfo\" : {    \"ExternalTripId\" : \"string\",    \"RouteId\" : \"string\",    \"StopSequenceNo\" : 3  },  \"LoadCarrierId\" : \"string\",  \"PowerUnitId\" : \"string\",  \"OrgUnitIdForAction\" : \"string\",  \"LocationID\" : \"string\",  \"GetEvents\" : \"string\",  \"GetVASPayment\" : false,  \"GetExtended\" : true,  \"GetPackageType\" : true,  \"GetAllItems\" : true,  \"ValidationType\" : \"Consignment\",  \"ValidationLevel\" : \"Plan\",  \"LoggingInformation\" : {    \"LogonName\" : \"string\",    \"SystemCode\" : \"string\",    \"LanguageCode\" : \"string\",    \"CompanyCode\" : \"string\",    \"CountryCode\" : \"string\",    \"OrgUnitId\" : \"string\",    \"UserRole\" : \"string\",    \"ProcessName\" : \"string\",    \"SubProcessName\" : \"string\",    \"SubProcessVersion\" : \"string\",    \"InterfaceVersion\" : \"string\",    \"InvocationTime\" : \"2006-08-19T19:27:14+02:00\",    \"MessageId\" : \"string\"  },  \"CustomerId\" : \"string\",  \"OrderNumber\" : \"string\",  \"TMSAffiliationId\" : \"string\"}";


        //        //test = "{  \"Id\": 0,  \"Name\": \"string\",  \"EmailAddress\": \"string\"}";

        //        //RootObject ge = BindGoodsEvents();
        //        //var json = JsonConvert.SerializeObject(ge);
        //        //// json = json.Replace("HeaderNew", "Header");

        //        HttpContent stringContent = new StringContent(test, UnicodeEncoding.UTF8, "application/json");

        //        HttpResponseMessage response = await client.PostAsync("", stringContent);

        //        //StringContent stringContent = new StringContent(test, UnicodeEncoding.UTF8, "application/json");


        //        // StringContent content = new StringContent(test);

        //        // HTTP POST
        //        //  HttpResponseMessage response = await client.PutAsync("T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS", stringContent);
        //        // HttpResponseMessage response = await client.PutAsync(addon, stringContent);
        //        // HttpResponseMessage response = await client.PostAsync("", stringContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            //    // product = JsonConvert.DeserializeObject<Contact>(data);
        //            //    temp = "Success";
                   
        //            return true;
                   
        //        }
        //        return false;
        //    }

        //}


    }
}
