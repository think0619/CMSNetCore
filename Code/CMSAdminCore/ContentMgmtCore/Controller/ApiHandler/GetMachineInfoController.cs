using ContentMgmtCore.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContentMgmtCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMachineInfoController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public GetMachineInfoController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpPost("GetMachineInfoByQRCode")]
        public void GetMachineInfoByQRCode()
        {
            //var keyname = "qrcode";
            //var qrcodeValue = "";

            //try
            //{
            //    if (Request.Form != null && Request.Form.ContainsKey(keyname))
            //    {
            //        qrcodeValue = Request.Form[keyname];
            //    }
            //}
            //catch (Exception)
            //{
            //    if (Request.Query.ContainsKey(keyname))
            //    {
            //        qrcodeValue = Request.Query[keyname];
            //    }
            //    else
            //    {

            //        using (StreamReader stream = new StreamReader(Request.Body))
            //        {
            //            string body =await stream.ReadToEndAsync();
            //            var requestData = JsonHelper.DeserializeJsonToObject<QRRequest>(body);
            //            if (requestData != null)
            //            {
            //                qrcodeValue = requestData.qrcode;
            //            }
            //        }
            //    }
            //}

            //string result = String.Empty;
            //if (!String.IsNullOrEmpty(qrcodeValue))
            //{
            //    using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
            //    {
            //        var machineinfo = dbcontext.tb_machineInfo.Where(x => x.State == 1 && qrcodeValue.Equals(x.QRCode)).FirstOrDefault();
            //        result = machineinfo == null ? "" : JsonHelper.SerializeObject(machineinfo); 
            //    }
            //} 
           // return result;
        } 
    }

    public class QRRequest
    {
        public string qrcode { get; set; }
    }

}
