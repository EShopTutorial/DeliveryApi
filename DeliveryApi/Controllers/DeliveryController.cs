using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using DeliveryApi.Services;
using DeliveryApi.Models;

namespace DeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryService _deliveryService;

        public DeliveryController(DeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public ActionResult<List<DeliveryItem>> Get() =>
            _deliveryService.Get();


        [HttpGet("{id:length(24)}", Name = "GetDelivery")]
        public ActionResult<DeliveryItem> Get(string id)
        {
            var delivery = _deliveryService.Get(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        [HttpPost]
        public ActionResult<DeliveryItem> Create(DeliveryItem delivery)
        {
            _deliveryService.Create(delivery);

            return CreatedAtRoute("GetDelivery", new { id = delivery.Id.ToString() }, delivery);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, DeliveryItem deliveryIn)
        {
            var delivery = _deliveryService.Get(id);

            if (delivery == null)
            {
                return NotFound();
            }

            _deliveryService.Update(id, deliveryIn);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var delivery = _deliveryService.Get(id);

            if (delivery == null)
            {
                return NotFound();
            }

            _deliveryService.Remove(delivery.Id);

            return NoContent();
        }

    }
}