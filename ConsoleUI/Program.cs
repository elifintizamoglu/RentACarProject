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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2} {3}", car.BrandName, car.Description, car.ColorName, car.DailyPrice);
            }
            //BrandTest();
            //ColorTest();
            //CarTestLessonDay8();
        }



        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Mercedes" });
            colorManager.Update(new Color { Id = 1002, ColorName = "Green" });
            colorManager.Delete(new Color { Id = 1002, ColorName = "Green" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0}  {1} ", color.Id, color.ColorName);
            }

            Console.WriteLine("Id=1 belongs to color {0} ", colorManager.Get(1).ColorName);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Update(new Brand { Id = 13, BrandName = "BMW" });
            brandManager.Delete(new Brand { Id = 13, BrandName = "BMW" });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0}  {1} ", brand.Id, brand.BrandName);
            }

            Console.WriteLine("Id=1 belongs to brand {0} ", brandManager.Get(1).BrandName);
        }
        private static void CarTestLessonDay8()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Tüm arabaların listelenmesi
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("\n");

            //BrandId'ye göre arabaları bulma
            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("\n");

            //ColorId'ye göre arabaları bulma
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("\n");

            //Araba ekleme
            carManager.Add(new Car { BrandId = 5, ColorId = 6, ModelYear = 2018, DailyPrice = 139, Description = "Clio 5" });

            //Araba güncelleme
            carManager.Update(new Car
            {
                Id = 20,
                BrandId = 5,
                ColorId = 6,
                DailyPrice = 139,
                ModelYear = 2018,
                Description = "Clio 5 is updated."
            });

            //Araba silme
            carManager.Delete(new Car { Id = 20, BrandId = 5, ColorId = 6, ModelYear = 2018, DailyPrice = 139, Description = "Clio 5 is updated." });

            //İstenen arabanın özelliklerini getirme
            var searchedCar = carManager.Get(11);
            Console.WriteLine(searchedCar.Description);
            Console.WriteLine(searchedCar.DailyPrice);
        }
    }
}
