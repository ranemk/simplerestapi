using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smarthousedevices.Data;
using smarthousedevices.Models;
using smarthousedevices.Models.Entities;

namespace smarthousedevices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public DeviceController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllDevices()
        {

            return Ok(dbContext.Devices.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetDevice(Guid id)
        {
            var device = dbContext.Devices.Find(id);

            if (device is null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpPost]
        public IActionResult AddDevice(AddDeviceDto deviceDto)
        {
            var DeviceEntity = new Device()
            {
                Name = deviceDto.Name,
                Type = deviceDto.Type,
            };
            dbContext.Devices.Add(DeviceEntity);
            dbContext.SaveChanges();
            return Ok(DeviceEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateDevice(Guid id, UpdateDeviceDto deviceDto)
        {
            var device = dbContext.Devices.Find(id);

            if  (device is null)
            {
                return NotFound();
            }
            device.Name = deviceDto.Name;
            device.Type = deviceDto.Type;
            dbContext.SaveChanges();
            return Ok(device);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteDevice(Guid id)
        {
            var device = dbContext.Devices.Find(id);

            if (device is null)
            {
                return NotFound();
            }

            dbContext.Devices.Remove(device);
            dbContext.SaveChanges();
            return Ok(device);
        }
    }
}
