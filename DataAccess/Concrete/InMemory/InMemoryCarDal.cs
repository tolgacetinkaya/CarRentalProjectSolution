using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {

            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=2,ModelYear=new DateTime(2015,5,29),DailyPrice=250,Description="Renault Fluence 2015 Model Siyah renkli günlük kirası : 250 tl"  },
                new Car{CarId=2,BrandId=2,ColorId=3,ModelYear=new DateTime(2020,8,15),DailyPrice=500,Description="Wolksvagen Passat 2020 Model Gri renkli günlük kirası : 500 tl" },
                new Car{CarId=3,BrandId=5,ColorId=4,ModelYear=new DateTime(2021,1,20),DailyPrice=700,Description="PEUGEOT 508 2021 Model Kırmızı renkli günlük kirası : 700 tl" },
                new Car{CarId=4,BrandId=4,ColorId=3,ModelYear=new DateTime(2017,8,16),DailyPrice=600,Description="BMW 320d 2017 Model Gri renkli günlük kirası : 600 tl" },
                new Car{CarId=5,BrandId=3,ColorId=1,ModelYear=new DateTime(2013,12,10),DailyPrice=325,Description="Mercedes E300 2013 Model Beyaz renkli kirası : 325 tl" },
                new Car{CarId=6,BrandId=6,ColorId=2,ModelYear=new DateTime(2019,9,25),DailyPrice=450,Description="Seat Leon 2019 Model Kırmızı renkli günlük kirası : 450 tl" }

            };


        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
