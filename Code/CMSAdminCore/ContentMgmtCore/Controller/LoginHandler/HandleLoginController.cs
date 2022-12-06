using ContentMgmtCore.DBContext;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentMgmtCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandleLoginController : ControllerBase
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public HandleLoginController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        //[HttpPost("LoginV")]
        //public string LoginV([FromForm] string password, [FromForm] string username)
        //{
        //    LoginTipResult tr = new LoginTipResult()
        //    {
        //        Status = 0,
        //        Msg = "操作异常，请刷新页面",
        //        Token = ""
        //    };

        //    if (!String.IsNullOrWhiteSpace(password) && !String.IsNullOrWhiteSpace(username))
        //    {
        //        try
        //        {
        //            string passwdMD5 = CreateMD5(password);
        //            using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
        //            {
        //                var validUserInfo = dbcontext.tb_loginuser.Where(x => (x.UserName.Equals(username)
        //                                                                  && x.Status == 1
        //                                                                  && (x.Password.Equals(passwdMD5)))).FirstOrDefault();
        //                if (validUserInfo != null)
        //                {
        //                    tr.TokenInfo = Guid.NewGuid().ToString().Replace("-", "");
        //                    dbcontext.tb_logintoken.Add(new LoginToken()
        //                    {
        //                        Createtime = DateTime.Now,
        //                        LoginGuid = tr.TokenInfo,
        //                        Status = 1,
        //                    });

        //                    tr.Status = 1;
        //                    tr.Msg = "验证通过";
        //                }
        //                else
        //                {
        //                    tr.Status = 0;
        //                    tr.Msg = "用户名或密码错误";
        //                }
        //                dbcontext.SaveChanges();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            tr.Status = 0;
        //            tr.Msg = "系统异常";
        //        }
        //    }
        //    else
        //    {
        //        tr.Status = 0;
        //        tr.Msg = "请输入完整的用户名 密码";
        //    }

        //    return JsonHelper.SerializeObject(tr);
        //}

        //[HttpPost("VerifyLogin")]
        //public string VerifyLogin([FromForm] string loginguid)
        //{
        //    TipResult tr = new TipResult()
        //    {
        //        Status=0,
        //        Msg =""
        //    };
        //    //only 30m
        //    if (!String.IsNullOrWhiteSpace(loginguid))
        //    {
        //        try
        //        { 
        //            using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
        //            {
        //                var loginInfo = dbcontext.tb_logintoken.Where(x => x.LoginGuid.Equals(loginguid) && x.Status==1).FirstOrDefault();
        //                if (loginInfo != null)
        //                {
        //                    var subttractSec = DateTime.Now.Subtract(loginInfo.Createtime).TotalSeconds;
        //                    if (subttractSec <= (20 * 60))
        //                    {
        //                        tr.Status = 1;
        //                    }
        //                    else 
        //                    {
        //                        tr.Status = 0;
        //                        loginInfo.Status = 0;
        //                        dbcontext.SaveChanges();
        //                    } 
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            tr.Status = 0;
        //        } 
        //    }

        //    return JsonHelper.SerializeObject(tr);
        //}


        public static string CreateMD5(string s)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var encoding = Encoding.ASCII;
                var data = encoding.GetBytes(s);

                Span<byte> hashBytes = stackalloc byte[16];
                md5.TryComputeHash(data, hashBytes, out int written);
                if (written != hashBytes.Length)
                    throw new OverflowException();


                Span<char> stringBuffer = stackalloc char[32];
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashBytes[i].TryFormat(stringBuffer.Slice(2 * i), out _, "x2");
                }
                return new string(stringBuffer);
            }
        }
    }
}
