using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear= 2001, DailyPrice= 100,Description="Audi"},
                new Car{Id=2,BrandId=2,ColorId=1,ModelYear= 2002, DailyPrice= 200,Description="BMW"},
                new Car{Id=3,BrandId=3,ColorId=2,ModelYear= 2003, DailyPrice= 300,Description="Honda"},
                new Car{Id=4,BrandId=4,ColorId=2,ModelYear= 2004, DailyPrice= 400,Description="Opel"},
                new Car{Id=5,BrandId=5,ColorId=2,ModelYear= 2005, DailyPrice= 500,Description="Toyota"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.Id + " added. \n ");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine(car.Id + " deleted. ");
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            Console.WriteLine(car.Id + " updated. ");
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
