using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Service;
using WebAPI.Domain;
using WebAPI.Application.Models;
using WebAPI.Application.Filters;

namespace ceconsoftAPI.Application.Controllers
{
    [ApiKeyAuthentication]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login([FromBody] LoginModel user)
        {
            try
            {
                var jwt = _userService.login(user);
                Response.StatusCode = 200;
                return Json(jwt);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                  
                Exception realerror = ex;
                while (realerror.InnerException != null)
                realerror = realerror.InnerException;
                return Json(realerror.Message);  
            }
             
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var allUser = _userService.getAll();
                Response.StatusCode = 200;
                return Json(allUser);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
        }

        [Route("{ID:int}")]
        [HttpGet]
        public ActionResult GetByID(int ID)
        {
            try
            {
                var user = _userService.getByID(ID);
                Response.StatusCode = 200;
                return Json(user);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
            
            
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([FromBody] UserModel user)
        {
            try
            {
                var addedUser = _userService.add(user);
                Response.StatusCode = 200;
                return Json(addedUser);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                  
                Exception realerror = ex;
                while (realerror.InnerException != null)
                realerror = realerror.InnerException;
                return Json(realerror.Message);  
            }
             
        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update([FromBody] UserModel user)
        {
            try
            {
                var updatedUser = _userService.update(user);
                Response.StatusCode = 200;
                return Json(updatedUser);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
             
        }

        [Route("delete/{ID:int}")]
        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            try
            {
                _userService.delete(ID);
                Response.StatusCode = 200;
                return Json(new {message= "Deleted Successfully"});
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
             
        }

    }
}