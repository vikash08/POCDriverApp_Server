using Microsoft.Azure.Mobile.Server;

namespace POCDriverAppService.DataObjects
{
    public class ValidateGood : EntityData
    {
        public string ConsignmentItemNumber { get; set; }

        public bool IsValid { get; set; }
        

    }
}