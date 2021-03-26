using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Helpers;
using DataAccess.Concrete.EntityFramework;
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
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = new CarImageManager(new EfCarImageDal());
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage entity, [FromForm(Name = "Image")] IFormFile file = null)
        {
            var res = _carImageService.Add(entity, file);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage entity)
        {
            var res = _carImageService.Delete(entity);

            if (res.Success)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage entity)
        {
            var res = _carImageService.Update(entity, file);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var res = _carImageService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var res = _carImageService.GetByCarId(carId);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var res = _carImageService.GetById(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
