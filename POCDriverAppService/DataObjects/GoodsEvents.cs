using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCDriverAppService.DataObjects
{

    public class UserInformation
    {
        public string UserLogonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserOrgUnitId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ConsignmentItem
    {
        public string ConsignmentItemNumber { get; set; }
    }

    public class Consignment
    {
        public string EventType { get; set; }
        public string ConsignmentNumber { get; set; }
        public List<ConsignmentItem> ConsignmentItem { get; set; }
    }

    //public class Signature
    //{
    //    public string SignatureId { get; set; }
    //    public string Signature { get; set; }
    //    public string RecipientName { get; set; }
    //    public DateTime SignatureTime { get; set; }
    //}

    public class EventInformation
    {
        public string EventCode { get; set; }
        public DateTime EventTime { get; set; }
        public List<Consignment> Consignment { get; set; }
        public Signature Signature { get; set; }
    }

    public class LocationInformation
    {
        public string EventOrgUnitId { get; set; }
        public string EventPostalCode { get; set; }
        public string EventCountryCode { get; set; }
        public string EventCompanyCode { get; set; }
    }

    public class CaptureEquipment
    {
        public string CaptureEquipmentId { get; set; }
        public string CaptureEquipmentType { get; set; }
    }

    public class OperationInformation
    {
        public string PlanId { get; set; }
        public string PhysicalLoadCarrier { get; set; }
        public string OperationOriginSystem { get; set; }
        public string PowerUnitId { get; set; }
        public string RouteId { get; set; }
    }

    public class LoggingInformation
    {
        public DateTime TimeFromClient { get; set; }
        public DateTime TimeToIntegrationServer { get; set; }
        public string ProcessName { get; set; }
        public string SubProcessName { get; set; }
        public string SubProcessVersion { get; set; }
    }

    public class GoodsEvents
    {
        public UserInformation UserInformation { get; set; }
        public EventInformation EventInformation { get; set; }
        public LocationInformation LocationInformation { get; set; }
        public CaptureEquipment CaptureEquipment { get; set; }
        public OperationInformation OperationInformation { get; set; }
        public LoggingInformation LoggingInformation { get; set; }
        public string TMSAffiliationId { get; set; }
    }


    //public class Property
    //{
    //    public string Name { get; set; }
    //    public string Value { get; set; }
    //}

    //public class ConfigurationProperties
    //{
    //    public List<Property> Property { get; set; }
    //}

    //public class SequenceProperties
    //{
    //    public int OrderedSequenceNumber { get; set; }
    //    public string OrderedBatchID { get; set; }
    //    public string OrderedFlowName { get; set; }
    //    public int OrderedThresholdSequence { get; set; }
    //    public DateTime OrderedThresholdDateTime { get; set; }
    //}

    public class Header2
    {
        //public string MessageId { get; set; }
        //public string MessageType { get; set; }
        //public string MessageMode { get; set; }
        //public string ContextReference { get; set; }
        //public string Action { get; set; }
        //public string Version { get; set; }
        //public DateTime FirstProcessedTimestamp { get; set; }
        //public DateTime ProcessedTimestamp { get; set; }
        //public DateTime SourceSystemTimestamp { get; set; }
        //public DateTime TargetSystemTimestamp { get; set; }
        //public string SecurityToken { get; set; }
        //public string SourceCompany { get; set; }
        public string SourceSystem { get; set; }
        public string SourceSystemUser { get; set; }
        //public string SourceSystemRef { get; set; }
        //public ConfigurationProperties ConfigurationProperties { get; set; }
        //public SequenceProperties SequenceProperties { get; set; }
    }

    public class Header
    {
        //public Header2 HeaderNew;

    }

    //public class UserInformation
    //{
    //    public string UserLogonId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string UserOrgUnitId { get; set; }
    //    public string PhoneNumber { get; set; }
    //}

    //public class TransportEquipment
    //{
    //    public string EquipmentType { get; set; }
    //    public int NumberOf { get; set; }
    //}

    //public class PackageType
    //{
    //    public string Type { get; set; }
    //    public int NumberOf { get; set; }
    //}

    ////public class Picture
    ////{
    ////    public string PictureId { get; set; }
    ////    public int PictureNumber { get; set; }
    //////    private string Picture;


    ////}

    //public class ConsignmentItem
    //{
    //    public string ConsignmentItemNumber { get; set; }
    //    public string PackageType { get; set; }
    //    public int Weight { get; set; }
    //    public string WeightUnit { get; set; }
    //    public int Height { get; set; }
    //    public int Length { get; set; }
    //    public int Width { get; set; }
    //    public string HLWUnit { get; set; }
    //    //public List<Picture> Picture { get; set; }
    //}

    ////public class Picture2
    ////{
    ////    public string PictureId { get; set; }
    ////    public int PictureNumber { get; set; }
    ////    public string Picture { get; set; }
    ////}

    //public class Consignment
    //{
    //    public string EventType { get; set; }
    //    public string CustomerNumber { get; set; }
    //    public string ConsignmentNumber { get; set; }
    //    public bool MassRegistration { get; set; }
    //    public int ConsignmentItemsHandled { get; set; }
    //    public int Weight { get; set; }
    //    public string WeightUnit { get; set; }
    //    public int Volume { get; set; }
    //    public string VolumeUnit { get; set; }
    //    public List<TransportEquipment> TransportEquipment { get; set; }
    //    public List<PackageType> PackageType { get; set; }
    //    public string OrderNumber { get; set; }
    //    public string ProductCategory { get; set; }
    //    public List<ConsignmentItem> ConsignmentItem { get; set; }
    //    //public List<Picture2> Picture { get; set; }
    //}

    public class Signature
    {
        public string SignatureId { get; set; }
        public string SignatureNew { get; set; }
        public string RecipientName { get; set; }
        public DateTime SignatureTime { get; set; }
    }

    //public class EventInformation
    //{
    //    public bool HDHEvent { get; set; }
    //    public string EventCode { get; set; }
    //    public string CauseCode { get; set; }
    //    public string ActionCode { get; set; }
    //    public string DamageCode { get; set; }
    //    public DateTime EventTime { get; set; }
    //    public DateTime UtcTime { get; set; }
    //    public string TimeDiff { get; set; }
    //    public string EventStatus { get; set; }
    //    public string EventComment { get; set; }
    //    public string EventCoordinateX { get; set; }
    //    public string EventCoordinateY { get; set; }
    //    public string EventCoordinatesystem { get; set; }
    //    public double EventTemperature { get; set; }
    //    public string TemperatureZone { get; set; }
    //    public string TemperatureUnit { get; set; }
    //    public string PostalCode { get; set; }
    //    public string CountryCode { get; set; }
    //    public List<Consignment> Consignment { get; set; }
    //    public DateTime AdditionalTime { get; set; }
    //    public string TimestampCode { get; set; }
    //    //public Signature Signature { get; set; }
    //    public string RecipientId { get; set; }
    //    public string IdentificationDocumentType { get; set; }
    //    public string ShelfLocation { get; set; }
    //    public string OrgUnitIdDeliveredTo { get; set; }
    //    public string EventCodeFromUserProcess { get; set; }
    //    public string AuthorizationCode { get; set; }
    //}

    //public class LocationInformation
    //{
    //    public string EventOrgUnitId { get; set; }
    //    public string EventPostalCode { get; set; }
    //    public string EventCountryCode { get; set; }
    //    public string EventCompanyCode { get; set; }
    //    public string LocationId { get; set; }
    //}

    //public class CaptureEquipment
    //{
    //    public string CaptureEquipmentId { get; set; }
    //    public string CaptureEquipmentType { get; set; }
    //}

    //public class CombinationTripInfo
    //{
    //    public string TripId { get; set; }
    //    public string Route { get; set; }
    //}

    //public class OperationInformation
    //{
    //    public string TripId { get; set; }
    //    public string ExternalTripId { get; set; }
    //    public string StopId { get; set; }
    //    public string PlanId { get; set; }
    //    public string OperationListId { get; set; }
    //    public string LoadCarrier { get; set; }
    //    public string PhysicalLoadCarrier { get; set; }
    //    public string OperationOriginSystem { get; set; }
    //    public List<string> ValueAddedService { get; set; }
    //    public string PowerUnitId { get; set; }
    //    public string RouteId { get; set; }
    //   // public CombinationTripInfo invalid { get; set; }
    //}
    //public class LoggingInformation
    //{
    //    public DateTime TimeFromClient { get; set; }
    //    public DateTime TimeToIntegrationServer { get; set; }
    //    public DateTime TimeDeliveredToInterface { get; set; }
    //    public string ConnectionCode { get; set; }
    //    public string ConnectionState { get; set; }
    //    public string ProcessName { get; set; }
    //    public string SubProcessName { get; set; }
    //    public string SubProcessVersion { get; set; }
    //}

    //public class GoodsEvents
    //{
    //    public UserInformation UserInformation { get; set; }
    //    public EventInformation EventInformation { get; set; }
    //    public LocationInformation LocationInformation { get; set; }
    //    public CaptureEquipment CaptureEquipment { get; set; }
    //    public string EventSystemCode { get; set; }
    //    public OperationInformation OperationInformation { get; set; }
    //    public LoggingInformation LoggingInformation { get; set; }
    //    public string TMSAffiliationId { get; set; }
    //}

    public class Body
    {
        public GoodsEvents GoodsEvents { get; set; }
    }

    public class RootObject
    {
        // public Header Header { get; set; }
        public Body Body { get; set; }
    }

}
