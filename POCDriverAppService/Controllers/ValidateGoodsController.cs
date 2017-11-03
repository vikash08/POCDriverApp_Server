using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace POCDriverAppService.Controllers
{
    [MobileAppController]
    public class ValidateGoodsController : ApiController
    {
        //// GET api/ValidateGoods
        //public string Get()
        //{
        //    return "Hello from custom controller!";
        //}

        // GET api/ValidateGoods
        public string Get(string Item)
        {
            if (Item.Length < 12)
            {
                return "false";

            }
            else
            {
                return "true";
            }
            
        }

    }
}
