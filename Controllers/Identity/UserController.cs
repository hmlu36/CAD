using System;
using Anotar.Log4Net;
using Dotnet.Models.Identity;
using Dotnet.Models.Web;
using Dotnet.Services.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Controllers.Identity {

    [Route("[controller]")]
    public class UserController : Controller {
        private readonly IGenericService<User> service;

        public UserController(IGenericService<User> service) {
            this.service = service;
        }

        [HttpGet("{id}")]
        public ResultModel Get(Guid id) {
            var result = new ResultModel();
            result.Data = service.Get(u => u.Id.Equals(id), u => u.UserRoles);
            result.IsSuccess = true;
            return result;
        }

        [HttpGet("GetRoles/{id}")]
        public ResultModel GetRoles(Guid id) {
            var result = new ResultModel();

            result.Data = service.Get(u => u.Id.Equals(id), u => u.UserRoles);

            result.IsSuccess = true;
            return result;
        }

        [HttpPost]
        public ResultModel Post([FromBody] User user) {
            var result = new ResultModel();
            service.Insert(user);
            result.Data = user.Id;
            result.IsSuccess = true;
            return result;
        }

        [HttpPut]
        public ResultModel Put([FromBody] User user) {
            LogTo.Debug("user:" + user);
            var result = new ResultModel();
            service.Update(user);
            result.Data = user;
            result.IsSuccess = true;
            return result;
        }

        [HttpDelete("{id}")]
        public ResultModel Delete(string id) {
            var result = new ResultModel();
            service.Delete(id);
            result.IsSuccess = true;
            return result;
        }
    }
}