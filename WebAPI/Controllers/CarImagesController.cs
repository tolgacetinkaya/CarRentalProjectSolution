using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("uploadcarimage")]
        public IActionResult UploadImagesForCar([FromForm] IFormFile file, [FromForm] int carId)
        {
            CarImage carImage = new CarImage()
            {
                CarId = carId
            };
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateImagesForCar([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
           
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecarimage")]
        public IActionResult DeleteImagesForCar(CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarimage")]
        public IActionResult GetAllCarImage(int carId) {

            var result = _carImageService.GetAllPhotosForACar(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
    }
}
