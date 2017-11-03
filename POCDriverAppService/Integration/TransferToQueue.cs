using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using POCDriverAppService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCDriverAppService.Integration
{
    public class TransferToQueue
    {


        public bool SendMessageToQueue(Goodsevent item)
        {
            try
            {

                RootObject ge = CreateGoodsEvents(item);
                var json = JsonConvert.SerializeObject(ge);

               json= json.Replace("SignatureNew", "Signature");
                var connectionString = "Endpoint=sb://driverappsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SZGSDAGtJBIrt0YHSPMKby2j7tfHBsoMJREyUTq4QbA=";

                var queueName = "goodsevents";
                var client = QueueClient.CreateFromConnectionString(connectionString, queueName);



                var message = new BrokeredMessage(json);

                client.Send(message);

            }
            catch (System.Exception e)
            {
                return false;
            }
            return true;
        }

        public RootObject CreateGoodsEvents(Goodsevent itemFromClient)
        {

            GoodsEvents ge = new GoodsEvents();
            ge.CaptureEquipment = new CaptureEquipment();
            ge.CaptureEquipment.CaptureEquipmentId = "ANDROID";
            ge.CaptureEquipment.CaptureEquipmentType = "MOBILE";
            ge.EventInformation = new EventInformation();

            ConsignmentItem CI = new ConsignmentItem();
            CI.ConsignmentItemNumber = itemFromClient.Consignmentitemnumber;
            //CI.WeightUnit = "KG";
            //CI.Weight = 20;
            //CI.HLWUnit = "CM";
            //CI.Height = 2;
            //CI.Height = 4;
            //CI.Width = 3;
            Consignment C = new Consignment();
            C.ConsignmentItem = new List<ConsignmentItem>();
            C.ConsignmentItem.Add(CI);
            C.ConsignmentNumber = "70300490028029938";
            //C.WeightUnit = "KG";
            //C.Weight = 1;
            //C.VolumeUnit = "L";
            //C.Volume = 100;

            C.EventType = "ConsignmentItemEvent";

            ge.EventInformation.Consignment = new List<Consignment>();
            ge.EventInformation.Consignment.Add(C);
            ge.EventInformation.EventCode = itemFromClient.Eventcode;
            ge.EventInformation.EventTime = System.DateTime.UtcNow;
            ge.LocationInformation = new LocationInformation();
            ge.LocationInformation.EventCompanyCode = "POS";
            ge.LocationInformation.EventOrgUnitId = "101278";
            ge.LocationInformation.EventPostalCode = "3000";

            ge.EventInformation.Signature = new Signature {
                SignatureId="jshdj-adhaj-sadas-sada-adads",
                RecipientName="TestUser",SignatureTime=DateTime.UtcNow,
                SignatureNew= "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"


            }                ;
           
            
            var li = new LoggingInformation();
            li.TimeToIntegrationServer = DateTime.Now;
            ge.LoggingInformation = li;

            ge.OperationInformation = new OperationInformation();
            ge.OperationInformation.PowerUnitId = "MYCAR";
            ge.OperationInformation.PhysicalLoadCarrier = "MYLOADCAR";
            ge.OperationInformation.RouteId = "9999";
            ge.TMSAffiliationId = "NO_TMS";
            ge.OperationInformation.OperationOriginSystem = "FOT";
            var ui = new UserInformation();
            ui.UserLogonId = "660047";
            // Mandatory in old system
            //            ui.UserOrgUnitId = "100641";
            ui.FirstName = "Kumar";
            ui.LastName = "test";

            ge.UserInformation = ui;
            RootObject ro = new RootObject();
            ro.Body = new Body();
            //ro.Header = new Header();
            //ro.Header.HeaderNew = new Header2();
            //ro.Header.HeaderNew.SourceSystemUser = "660043";
            //ro.Header.HeaderNew.SourceSystem = "FOT";
            // ro.Header.HeaderNew.MessageId = Guid.NewGuid().ToString();
            //ro.Header.HeaderNew.SourceSystemTimestamp = DateTime.UtcNow;
            ro.Body.GoodsEvents = ge;

            return ro;
        }

    }
}