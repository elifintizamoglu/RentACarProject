using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            bool nameLength = true;
            bool dailyPrice = true;
            if (car.Description.Length < 2)
            {
                nameLength = false;
                Console.WriteLine("Araba ismi en az 2 karakter olmalıdır.");
            }
            if (car.DailyPrice <= 0)
            {
                dailyPrice = false;
                Console.WriteLine("Günlük fiyat 0'dan büyük olmalıdır.");
            }
            if (nameLength && dailyPrice)
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(b => b.BrandId == brandId);
        }

        public Car Get(int id)
        {
            return _carDal.Get(p => p.Id== id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
