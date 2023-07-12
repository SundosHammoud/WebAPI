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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var allRoles = _roleService.getAll();
                Response.StatusCode = 200;
                return Json(allRoles);
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
                var role = _roleService.getByID(ID);
                Response.StatusCode = 200;
                return Json(role);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
            
            
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([FromBody] RoleModel role)
        {
            try
            {
                var addedRole = _roleService.add(role);
                Response.StatusCode = 200;
                return Json(addedRole);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
             
        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update([FromBody] RoleModel role)
        {
            try
            {
                var updatedRole = _roleService.update(role);
                Response.StatusCode = 200;
                return Json(updatedRole);
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
                _roleService.delete(ID);
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