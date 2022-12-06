using ContentMgmtCore.Controller.CommonHandler;
using ContentMgmtCore.DBContext;
using ContentMgmtCore.Handlers;
using ContentMgmtCore.Model;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ContentMgmtCore.Controller.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private IConfiguration _config;
        private readonly IServiceScopeFactory _serviceScopeFactory;
      
        public LoginController(/*IConfiguration config,*/ IServiceScopeFactory serviceScopeFactory)
        {
            //_config = config;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [AllowAnonymous]
        [HttpPost]
        public string Login([FromBody] UserModel login)
        {
            LoginTipResult tipResult = new LoginTipResult()
            {
                Status = 0,
                Msg = "",
                Token = ""
            };
            //IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                tipResult.Token = tokenString;
                tipResult.Status = 1;
                tipResult.Msg = "success";
                // response = Ok(new { token = tokenString });
            }
            else 
            {
                tipResult.Status = 0;
                tipResult.Msg = "用户名或密码错误。";
            }
            return JsonHelper.SerializeObject(tipResult);
        }

        private string GenerateJSONWebToken(LoginUser userInfo)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, ConfigurationHelper.AppSetting["Jwt:ClaimName"]),
                new Claim(nameof(userInfo.UserName), userInfo.UserName),
                new Claim(nameof(userInfo.recid), userInfo.recid.ToString()),
                new Claim(nameof(userInfo.UserInfo), userInfo.UserInfo),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddMinutes(60)).ToUnixTimeSeconds().ToString()),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.AppSetting["Jwt:Key"]));
           
            string expireSeconds = ConfigurationHelper.AppSetting["Jwt:ExpireSeconds"];
          
            Int32.TryParse(expireSeconds, out int expire);

            var token = new JwtSecurityToken(
                ConfigurationHelper.AppSetting["Jwt:Issuer"],
                ConfigurationHelper.AppSetting["Jwt:Audience"],
                claims,
                null,
                DateTime.Now.AddSeconds(expire),
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));  
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Check user login info
        private LoginUser AuthenticateUser(UserModel loginuser)
        { 
            LoginUser user = null;
            if ((!String.IsNullOrWhiteSpace(loginuser.UserName)) && (!String.IsNullOrWhiteSpace(loginuser.Password)))
            {
                string enCryptPwd = EncryptHelper.CreateMD5(loginuser.Password);
                using (var dbcontext = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<DataConfigContext>())
                {
                    var checkUser = dbcontext.tb_loginuser.Where(u => u.Status == 1
                                                    && u.UserName.Equals(loginuser.UserName)
                                                    && u.Password.Equals(enCryptPwd)).FirstOrDefault();
                    if (checkUser != null) 
                    {
                        user = checkUser;
                    }
                }
            } 
            return user;
        }
    }
}
