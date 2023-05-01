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

        [HttpPut]
        [Route("{id:int}")]
        public Account Modify(int id, Account account)
        {
            Account result = null;
            account.Id = id; //update data
            result = _service.Update(account);
            return result;
        }
        
        
        [HttpDelete]
        [Route("{id:int}")]
        public bool Delete(int id)
        {
           bool result = false;
            
            result = _service.Delete(id);
            return result;
        }
    }
}