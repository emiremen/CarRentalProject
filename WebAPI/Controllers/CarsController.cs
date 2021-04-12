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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")] //localhost:44306/api/cars/getall
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")] //localhost:44306/api/cars/getall
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbyid")] //localhost:44306/api/cars/getcardetailsbyid?carId=4
        public IActionResult GetCarDetailsById(int carId)
        {
            var result = _carService.GetCarDetailsById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        

        [HttpGet("getcardetailsbybrandname")] //localhost:44306/api/cars/getcardetailsbybrandname?brandName=BMW
        public IActionResult GetCarDetailsByBrandName(string brandName)
        {
            var result = _carService.GetCarDetailsByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbycolorname")] //localhost:44306/api/cars/getcardetailsbycolorname?colorName=Beyaz
        public IActionResult GetCarDetailsByColorName(string colorName)
        {
            var result = _carService.GetCarDetailsByColorName(colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getcardetailsbyfiltered")] //localhost:44306/api/cars/getcardetailsbyfiltered??brandName=BMW&colorName=Beyaz
        public IActionResult GetCarDetailsByFiltered(string brandName, string colorName)
        {
            var result = _carService.GetCarDetailsByFiltered(brandName, colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addcar")] //localhost:44306/api/cars/addcar
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("update")] //localhost:44306/api/cars/update
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
