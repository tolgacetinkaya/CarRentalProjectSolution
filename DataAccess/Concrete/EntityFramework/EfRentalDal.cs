using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalProjectDbContext context = new CarRentalProjectDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                                 on r.CarId equals c.CarId
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             join cs in context.Customers
                                 on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                                 on cs.UserId equals u.Id
                             select new RentalDetailDto()
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 CustomerName = $"{u.FirstName} {u.LastName}",
                                 ModelName = c.ModelName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
