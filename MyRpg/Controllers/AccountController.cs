using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRpg.Services;

namespace MyRpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }
        
        [HttpPost]
        public Account Login(LoginModel account)
        {
            Account result = null; 
            if (_service.Verify(account.Username, account.Password))
            {
                result = _service.GetByUserName(account.Username);
            }
            return result;
        }
    }
}
