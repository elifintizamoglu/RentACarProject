﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByBrandId(int brandId);
        Car Get(int Id);
        List<CarDetailDto> GetCarDetails();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
