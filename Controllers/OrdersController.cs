using System;
using Cw13.DTOs;
using Cw13.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Cw13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ICukierniaDbService _service;

        public OrdersController(ICukierniaDbService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult getOrders(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return Ok(_service.GetOrders());
                else
                    return Ok(_service.GetOrders(name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}