using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using POCDriverAppService.DataObjects;
using POCDriverAppService.Models;
// Vikash Notification Hub
using System.Collections.Generic;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.Mobile.Server.Config;

using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;
using POCDriverAppService.Integration;

namespace POCDriverAppService.Controllers
{
    public class GoodsEventController : TableController<Goodsevent>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            POCDriverAppContext context = new POCDriverAppContext();
            DomainManager = new EntityDomainManager<Goodsevent>(context, Request);
        }

        // GET tables/Goodsevent
        public IQueryable<Goodsevent> GetAllGoodsevents()
        {
            return Query();
        }

        // GET tables/Goodsevent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Goodsevent> GetGoodsevent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Goodsevent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Goodsevent> PatchGoodsevent(string id, Delta<Goodsevent> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Goodsevent
        [HttpPost]
        public async Task<IHttpActionResult> PostGoodsevent(Goodsevent item)
        {
           
            Goodsevent current = await InsertAsync(item);

            try
            {
                TransferToQueue tq = new TransferToQueue();
                tq.SendMessageToQueue(item);
            }
            catch (Exception e)
            {

            }

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        //public bool SendMessageToQueue(Goodsevent item)
        //{
        //    try
        //    {

        //        RootObject ge = CreateGoodsEvents(item);
        //        var json = JsonConvert.SerializeObject(ge);
              
        //        var connectionString = "Endpoint=sb://driverappsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SZGSDAGtJBIrt0YHSPMKby2j7tfHBsoMJREyUTq4QbA=";
                
        //        var queueName = "goodsevents";
        //        var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

             

        //         var message = new BrokeredMessage(json );

        //        client.Send(message);

        //    }
        //    catch (System.Exception e)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public RootObject CreateGoodsEvents(Goodsevent itemFromClient)
        //{

        //    GoodsEvents ge = new GoodsEvents();
        //    ge.CaptureEquipment = new CaptureEquipment();
        //    ge.CaptureEquipment.CaptureEquipmentId = "ANDROID";
        //    ge.CaptureEquipment.CaptureEquipmentType = "MOBILE";
        //    ge.EventInformation = new EventInformation();

        //    ConsignmentItem CI = new ConsignmentItem();
        //    CI.ConsignmentItemNumber = itemFromClient.Consignmentitemnumber;
        //    //CI.WeightUnit = "KG";
        //    //CI.Weight = 20;
        //    //CI.HLWUnit = "CM";
        //    //CI.Height = 2;
        //    //CI.Height = 4;
        //    //CI.Width = 3;
        //    Consignment C = new Consignment();
        //    C.ConsignmentItem = new List<ConsignmentItem>();
        //    C.ConsignmentItem.Add(CI);
        //    C.ConsignmentNumber = "70300490028029938";
        //    //C.WeightUnit = "KG";
        //    //C.Weight = 1;
        //    //C.VolumeUnit = "L";
        //    //C.Volume = 100;

        //    C.EventType = "ConsignmentItemEvent";

        //    ge.EventInformation.Consignment = new List<Consignment>();
        //    ge.EventInformation.Consignment.Add(C);
        //    ge.EventInformation.EventCode = itemFromClient.Eventcode;
        //    ge.EventInformation.EventTime = System.DateTime.UtcNow;
        //    ge.LocationInformation = new LocationInformation();
        //    ge.LocationInformation.EventCompanyCode = "POS";
        //    ge.LocationInformation.EventOrgUnitId = "101278";
        //    ge.LocationInformation.EventPostalCode = "3000";

        //    var li = new LoggingInformation();
        //    li.TimeToIntegrationServer = DateTime.Now;
        //    ge.LoggingInformation = li;

        //    ge.OperationInformation = new OperationInformation();
        //    ge.OperationInformation.PowerUnitId = "MYCAR";
        //    ge.OperationInformation.PhysicalLoadCarrier = "MYLOADCAR";
        //    ge.OperationInformation.RouteId = "9999";
        //    ge.TMSAffiliationId = "NO_TMS";
        //    ge.OperationInformation.OperationOriginSystem = "FOT";
        //    var ui = new UserInformation();
        //    ui.UserLogonId = "660047";
        //    // Mandatory in old system
        //    //            ui.UserOrgUnitId = "100641";
        //    ui.FirstName = "Kumar";
        //    ui.LastName = "test";

        //    ge.UserInformation = ui;
        //    RootObject ro = new RootObject();
        //    ro.Body = new Body();
        //    //ro.Header = new Header();
        //    //ro.Header.HeaderNew = new Header2();
        //    //ro.Header.HeaderNew.SourceSystemUser = "660043";
        //    //ro.Header.HeaderNew.SourceSystem = "FOT";
        //    // ro.Header.HeaderNew.MessageId = Guid.NewGuid().ToString();
        //    //ro.Header.HeaderNew.SourceSystemTimestamp = DateTime.UtcNow;
        //    ro.Body.GoodsEvents = ge;

        //    return ro;
        //}

        //public  GoodsEvents  BindGoodsEvents();
        //{
        //GoodsEvents g = new GoodsEvents();        
        //return g;
        //}



        //private async void SendMessagetoEconnect()
        //{
        //    //string url = "https://posten-test2.servicebus.windows.net/posten-test2/T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS";
        //    // string url = "https://posten-test2.servicebus.windows.net/posten-test2/T50051_GoodsEventFromScanningApp";
        //    string url = "http://qec4lb.posten.no:9009/T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS ";
           
        //    //string addon = "T50051_GoodsEventFromScanningApp/T50051_GoodsEventFromScanningApp_PS";
        //    //ViewData["ADDitionalURL"] = addon;

        //   // string test = "{  \"consignmentnumber\" : \"string\",  \"consignmentitemnumber\" : \"string\",  \"deliverycode\" : \"string\",  \"tripid\" : \"string\",  \"stopid\" : \"string\",  \"actiontype\" : \"string\",  \"eventcode\" : \"string\",  \"externaltripid\" : \"string\",  \"routeid\" : \"string\",  \"stopsequenceno\" : 3,  \"combinationtripinfo\" : {    \"externaltripid\" : \"string\",    \"routeid\" : \"string\",    \"stopsequenceno\" : 3  },  \"loadcarrierid\" : \"string\",  \"powerunitid\" : \"string\",  \"orgunitidforaction\" : \"string\",  \"locationid\" : \"string\",  \"getevents\" : \"string\",  \"getvaspayment\" : false,  \"getextended\" : true,  \"getpackagetype\" : true,  \"getallitems\" : true,  \"validationtype\" : \"consignment\",  \"validationlevel\" : \"plan\",  \"logginginformation\" : {    \"logonname\" : \"string\",    \"systemcode\" : \"string\",    \"languagecode\" : \"string\",    \"companycode\" : \"string\",    \"countrycode\" : \"string\",    \"orgunitid\" : \"string\",    \"userrole\" : \"string\",    \"processname\" : \"string\",    \"subprocessname\" : \"string\",    \"subprocessversion\" : \"string\",    \"interfaceversion\" : \"string\",    \"invocationtime\" : \"2006-08-19t19:27:14+02:00\",    \"messageid\" : \"string\"  },  \"customerid\" : \"string\",  \"ordernumber\" : \"string\",  \"tmsaffiliationid\" : \"string\"}";

        //     string test = "{\"UserInformation\" : { \"UserLogonId\" :\"660047\", \"FirstName\" : \"Sameer\",\"LastName\" : \"Test\",\"UserOrgUnitId\" : \"736402\", \"PhoneNumber\" : \"96987834\" }, \"EventInformation\" : { \"EventCode\" : \"I\", \"EventTime\" : \"2016-07-07T17:11:25.064+02:00\", \"Consignment\" : [ { \"EventType\" : \"ConsignmentItemEvent\", \"ConsignmentNumber\" : \"70300490028029938\",\"ConsignmentItem\" : [ { \"ConsignmentItemNumber\" : \"TT100050000NO\" } ] } ],\"Signature\" : {\"SignatureId\" : \"751B5D46-12A1-48FE-8C3E-045CEF109764\",\"Signature\" : \"c2Nhbm5pbmdBcHA=\",\"RecipientName\" : \"Linn Haviken\",\"SignatureTime\" : \"2016-07-15T10:43:20.942+02:00\"}}, \"LocationInformation\" : { \"EventOrgUnitId\" : \"101278\", \"EventPostalCode\" : \"3003\", \"EventCountryCode\" : \"NO\", \"EventCompanyCode\" : \"POS\" }, \"CaptureEquipment\" : { \"CaptureEquipmentId\" : \"OT20502\", \"CaptureEquipmentType\" : \"PDA\" }, \"OperationInformation\" : { \"PlanId\" : \"string\", \"PhysicalLoadCarrier\" : \"string\", \"OperationOriginSystem\" : \"string\", \"PowerUnitId\" : \"string\", \"RouteId\" : \"2001\" }, \"LoggingInformation\" : { \"TimeFromClient\" : \"2014-06-27T21:41:15+02:00\", \"TimeToIntegrationServer\" : \"2017-08-17T07:44:20\", \"ProcessName\" : \"Loading\", \"SubProcessName\" : \"LoadDistribTruck\", \"SubProcessVersion\" : \"6.1.0.195\" }, \"TMSAffiliationId\" : \"NO_TMS\" } ";



        //    string x = await ReturnfromEconnectAsync(url, test);
        //    //ViewData["Response"] = x;
            
        //    //r.Message1 = x;
        //    // ModelState["Message1"].RawValue = x;
        //}





        //public async Task<string> ReturnfromEconnectAsync(string url,string test)
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

        //        RootObject ge = BindGoodsEvents();
        //        var json = JsonConvert.SerializeObject(ge);
        //        // json = json.Replace("HeaderNew", "Header");
                
        //        HttpContent stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

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

        //            return data.ToString();
        //        }
        //        return "failure";
        //    }

        //}


        //private void CreateGoodsEventsMessage()
        //{


        //}
        // DELETE tables/Goodsevent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGoodsevent(string id)
        {
            return DeleteAsync(id);
        }
    }
}