using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.AutoFac.Transaction;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;

            _carService = carService;
        }

       // [TransactionScopeAspect]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceded(carImage.CarId), CheckIfCarIsExists(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            string filePath = FileHelper.Add(formFile);

            if (filePath == null)
            {
                return new ErrorResult(Messages.FileUploadError);
            }
            carImage.DateAdded = DateTime.Now;
            carImage.ImagePath = filePath;
            _carImageDal.Add(carImage);

            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            FileHelper.Delete(carImage.ImagePath);
            return new SuccessResult(Messages.CarImageDeleted);
        }



        public IDataResult<List<CarImage>> GetAllPhotosForACar(int carId)
        {
           
            List <CarImage> carImages = _carImageDal.GetAll(c => c.CarId == carId);

            if (carImages.Count == 0)
            {
                CarImage carImage = new CarImage()
                {
                    CarId = carId,
                    ImagePath = $@"..\Images\DefaultCarPhoto.png",      // TODO:Project deploy save data path
                    DateAdded = DateTime.Now
                };

                carImages.Add(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(carImages);

        }


        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            string filePath = FileHelper.Add(formFile);

            if (filePath == null)
            {
                return new ErrorResult(Messages.FileUploadError);
            }

            FileHelper.Delete(carImage.ImagePath);
            carImage.DateAdded = DateTime.Now;
            carImage.ImagePath = filePath;
            _carImageDal.Update(carImage);

            return new SuccessResult();



        }

        private IResult CheckIfCarImagesLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarIsExists(int carId)
        {
            var result = _carService.GetById(carId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarIsNotExist);
            }
            return new SuccessResult();
        }
    }
}
