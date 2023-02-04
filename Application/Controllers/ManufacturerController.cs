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
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;    

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var allManufacturers = _manufacturerService.getAll();
                Response.StatusCode = 200;
                return Json(allManufacturers);
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
                var manufacturer = _manufacturerService.getByID(ID);
                Response.StatusCode = 200;
                return Json(manufacturer);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
            
            
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([FromBody] ManufacturerModel manufacturer)
        {
            try
            {
                var addedManufacturer = _manufacturerService.add(manufacturer);
                Response.StatusCode = 200;
                return Json(addedManufacturer);
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex.Message);                
            }
             
        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update([FromBody] ManufacturerModel manufacturer)
        {
            try
            {
                var updatedManufacturer = _manufacturerService.update(manufacturer);
                Response.StatusCode = 200;
                return Json(updatedManufacturer);
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
                _manufacturerService.delete(ID);
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