using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CustomerTest();
            //UserTest();
            //RentalTest();


        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine(userManager.GetById(4).Data.FirstName);

            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.Description + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 02, 03), ReturnDate = new DateTime(2021, 02, 10) });
            //rentalManager.Add(new Rental { CarId = 4, CustomerId = 2, RentDate = DateTime.Now });
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarId + " " + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        
    }
}
