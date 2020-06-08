using System;
using Cw13.DTOs;
using Cw13.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw13.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private ICukierniaDbService _service;

        public ClientsController(ICukierniaDbService service)
        {
            _service = service;
        }
        
        [HttpPost("{id}/orders")]
        public IActionResult AddNewOrder(int id, AddNewOrderRequest request)
        {
            try
            {
                return Ok(_service.AddNewOrder(id,request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}