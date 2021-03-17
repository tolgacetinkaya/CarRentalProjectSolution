using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {

            if (file.Length > 0)
            {
                string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\WebAPI\wwwroot\images");
                var uniqueFilename = Guid.NewGuid().ToString();
                string fileExtension = new FileInfo(file.FileName).Extension;
                string fileLocalPath = $@"{path}\{uniqueFilename}" + fileExtension;
                string filePath = $@"{uniqueFilename}" + fileExtension;


                using (var stream = new FileStream(fileLocalPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return filePath;
            }

            return null;
        }


        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

    }
}
