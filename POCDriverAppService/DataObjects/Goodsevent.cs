using Microsoft.Azure.Mobile.Server;

namespace POCDriverAppService.DataObjects
{
    public class Goodsevent : EntityData
    {
        public string Consignmentitemnumber { get; set; }

        public string Eventcode { get; set; }

        public byte[][] Picture { get; set; }
    }
}