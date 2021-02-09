using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddNewCarsToDb();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " " + car.ModelName + " " + car.ColorName + " renkli aracın günlük kirası : " + car.DailyPrice + " Türk lirasıdır.");
            }

            //DeleteTest(carManager);
            //UpdateTest(carManager);
        }

        private static void DeleteTest(CarManager carManager)
        {
            carManager.Delete(new Car { CarId = 9 }); //worked
        }

        private static void UpdateTest(CarManager carManager)
        {
            carManager.Update(new Car
            {
                CarId = 8,
                BrandId = 3,
                ColorId = 2,
                ModelYear = new DateTime(2021, 5, 12),
                DailyPrice = 525,
                Description = ("Mercedes AMG G63 2019 Model Siyah renkli günlük kirası : 525 tl")

            });
        }

        private static void AddNewCarsToDb()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = new DateTime(2015, 5, 29), DailyPrice = 250, Description = "Renault Fluence 2015 Model Siyah renkli günlük kirası : 250 tl" });
            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = new DateTime(2020, 8, 15), DailyPrice = 500, Description = "Wolksvagen Passat 2020 Model Gri renkli günlük kirası : 500 tl" });
            carManager.Add(new Car { BrandId = 5, ColorId = 4, ModelYear = new DateTime(2021, 1, 20), DailyPrice = 700, Description = "PEUGEOT 508 2021 Model Kırmızı renkli günlük kirası : 700 tl" });
            carManager.Add(new Car { BrandId = 4, ColorId = 3, ModelYear = new DateTime(2017, 8, 16), DailyPrice = 600, Description = "BMW 320d 2017 Model Gri renkli günlük kirası : 600 tl" });
            carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = new DateTime(2013, 12, 10), DailyPrice = 325, Description = "Mercedes E300 2013 Model Beyaz renkli kirası : 325 tl" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = new DateTime(2015, 5, 29), DailyPrice = 450, Description = "Renault Megane 2015 Model Gri renkli günlük kirası : 250 tl" });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 4,
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Seat Leon 2019 Model Kırmızı renkli günlük kirası : 450 tl"
            });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 2,
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Seat Leon 2019 Model Siyah renkli günlük kirası : 450 tl"
            });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 3,
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Seat Leon 2019 Model Gri renkli günlük kirası : 450 tl"
            });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Renault", ModelName = "Fluence" });
            brandManager.Add(new Brand { BrandName = "Wolksvagen", ModelName = "Passat" });
            brandManager.Add(new Brand { BrandName = "Mercedes", ModelName = "E300" });
            brandManager.Add(new Brand { BrandName = "BMW", ModelName = "320d" });
            brandManager.Add(new Brand { BrandName = "PEUGEOT", ModelName = "508" });
            brandManager.Add(new Brand { BrandName = "Seat", ModelName = "Leon" });
            brandManager.Add(new Brand { BrandName = "Renault", ModelName = "Megane" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Beyaz" });
            colorManager.Add(new Color { ColorName = "Siyah" });
            colorManager.Add(new Color { ColorName = "Gri" });
            colorManager.Add(new Color { ColorName = "Kırmızı" });
            colorManager.Add(new Color { ColorName = "Beyaz" });
        }
    }
}
