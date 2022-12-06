using ContentMgmtCore.DBContext;
using Entities.JsonEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ContentMgmtCore.Controller.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonHandlerController : ControllerBase
    { 
        private readonly IServiceScopeFactory _serviceScopeFactory;
      
        public CommonHandlerController(IServiceScopeFactory serviceScopeFactory)
        { 
            _serviceScopeFactory = serviceScopeFactory;
        }

      
    }
}
