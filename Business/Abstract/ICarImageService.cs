﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile file);
        IResult Update(int id, IFormFile file);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAllImages();
        IDataResult<CarImage> GetImagesById(int carId);
    }
}
