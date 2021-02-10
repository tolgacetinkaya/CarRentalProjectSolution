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
            //AddNewDataToDb();
            //DeleteTestForCars(carManager);
            //UpdateTestForCars(carManager);

            //ColorTest();

            //BrandTest();

            //CarTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} renk", color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} numaralı araç : {1} markadır. ", brand.BrandId, brand.BrandName);
            }
            //Console.WriteLine(brandManager.GetById(1).BrandName+" "+brandManager.GetById(1).ModelName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(" {0}  {1}  {2} renkli aracın günlük kirası {3} Türk lirasıdır.", car.BrandName, car.ModelName, car.ColorName, car.DailyPrice);
            }

            foreach (var car1 in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine();
            }
        }

        private static void DeleteTestForCars(CarManager carManager)
        {

            carManager.Delete(new Car { CarId = 9 }); //worked
        }

        private static void UpdateTestForCars(CarManager carManager)
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

        private static void AddNewDataToDb()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelName = "Fluence", ModelYear = new DateTime(2015, 5, 29), DailyPrice = 250, Description = "Haftalık kiralanırsa fiyatta %10 indirim olur" });
            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelName = "Passat", ModelYear = new DateTime(2020, 8, 15), DailyPrice = 500, Description = "Aylık kiralanırsa fiyatta %15 indirim olur" });
            carManager.Add(new Car { BrandId = 5, ColorId = 4, ModelName = "508", ModelYear = new DateTime(2021, 1, 20), DailyPrice = 700, Description = "Yıllık kiralanırsa fiyatta %12,5 indirim olur" });
            carManager.Add(new Car { BrandId = 4, ColorId = 3, ModelName = "320d", ModelYear = new DateTime(2017, 8, 16), DailyPrice = 600, Description = "Haftalık kiralanırsa fiyatta %10 indirim olur" });
            carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelName = "E300", ModelYear = new DateTime(2013, 12, 10), DailyPrice = 325, Description = "Aylık kiralanırsa fiyatta %15 indirim olur" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelName = "Megane", ModelYear = new DateTime(2015, 5, 29), DailyPrice = 450, Description = "Yıllık kiralanırsa fiyatta %16 indirim olur" });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 4,
                ModelName = "Leon",
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Haftalık kiralanırsa fiyatta %10 indirim olur"
            });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 6,
                ModelName = "Leon",
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Haftalık kiralanırsa fiyatta %10 indirim olur"
            });
            carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 3,
                ModelName = "Leon",
                ModelYear = new DateTime(2019, 9, 25),
                DailyPrice = 450,
                Description = "Haftalık kiralanırsa fiyatta %10 indirim olur"
            });

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Renault" });
            brandManager.Add(new Brand { BrandName = "Wolksvagen" });
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Add(new Brand { BrandName = "BMW" });
            brandManager.Add(new Brand { BrandName = "PEUGEOT" });
            brandManager.Add(new Brand { BrandName = "Seat" });


            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Beyaz" });
            colorManager.Add(new Color { ColorName = "Siyah" });
            colorManager.Add(new Color { ColorName = "Gri" });
            colorManager.Add(new Color { ColorName = "Kırmızı" });
            colorManager.Add(new Color { ColorName = "Beyaz" });
            colorManager.Add(new Color { ColorName = "Buz Mavisi" });
        }
    }
}
