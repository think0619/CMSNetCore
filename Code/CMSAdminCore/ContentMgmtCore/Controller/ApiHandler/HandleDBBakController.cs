using ContentMgmtCore.DBContext;
using ContentMgmtCore.Model;
using Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class HandleDBBakController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public HandleDBBakController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        [HttpPost("GetLastBak")]
        [HttpGet("GetLastBak")]
        public async Task<IActionResult> GetLastBak()
        {
            var loginUserID = HttpContext.Items[nameof(LoginUser.recid)];
            if (loginUserID != null)
            {
                try
                {
                    using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
                    {
                        var lastBakInfo = dbcontext.tb_dbbackinfo.Where(x => x.Status == 1).OrderByDescending(x => x.RecId).FirstOrDefault();
                        if (lastBakInfo != null) 
                        {
                            var filePath = lastBakInfo.FileAbsolutePath; 
                            //application/zip
                            //application/x-7z-compressed
                            if (System.IO.File.Exists(filePath))
                            {
                                string fileName = System.IO.Path.GetFileName(filePath);
                                string extension = Path.GetExtension(filePath).ToLower();
                                string contentType = "";
                                if (".7z".Equals(extension))
                                {
                                    contentType = "application/x-7z-compressed";
                                }
                                else if (".zip".Equals(extension))
                                {
                                    contentType = "application/zip";
                                }
                                var content = await System.IO.File.ReadAllBytesAsync(filePath);
                                return File(content, contentType, fileName);
                            }
                            else
                            {
                                return BadRequest();
                            }
                        }
                        else
                        {
                            return BadRequest();
                        }
                    } 
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpGet("UpdateDBBakInfo")]
        //[AllowAnonymous]
        [HttpPost("UpdateDBBakInfo")]
        public async Task<string> UpdateDBBakInfo(DBBakInfo _DBBakInfo)
        {
            TipResult tr = new TipResult()
            {
                Status = 0,
                Msg = ""
            };
            var loginUserID = HttpContext.Items[nameof(LoginUser.recid)];
            if (loginUserID != null)
            {
                if (_DBBakInfo != null && (!String.IsNullOrWhiteSpace(_DBBakInfo.FileName)))
                {
                    try
                    {
                        using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
                        {
                            _DBBakInfo.Status = 1;
                            _DBBakInfo.RecordTime = DateTime.Now;
                            await dbcontext.tb_dbbackinfo.AddAsync(_DBBakInfo);
                            await dbcontext.SaveChangesAsync();
                            tr.Status = 1;
                            tr.Msg = "Success.";
                        }
                    }
                    catch (Exception ex)
                    {
                        tr.Msg = ex.Message;
                    }
                }
            }
            else 
            {
                tr.Msg = "Unauthorized";
            } 
            return JsonHelper.SerializeObject(tr) ;
        }
    }


}
