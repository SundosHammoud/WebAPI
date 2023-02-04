using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Service;
using WebAPI.Domain;
using WebAPI.Application.Models;


namespace ceconsoftAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var allMachines = _machineService.getAll();
                Response.StatusCode = 200;
                return Json(allMachines);
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
                var machine = _machineService.getByID(ID);
                Response.StatusCode = 200;
                return Json(machine);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
            
            
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([FromBody] MachineModel machine)
        {
            try
            {
                var addedMachine = _machineService.add(machine);
                Response.StatusCode = 200;
                return Json(addedMachine);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
             
        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update([FromBody] MachineModel machine)
        {
            try
            {
                var updatedMachine = _machineService.update(machine);
                Response.StatusCode = 200;
                return Json(updatedMachine);
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
                _machineService.delete(ID);
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