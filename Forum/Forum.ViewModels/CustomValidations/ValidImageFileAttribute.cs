using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Forum.ViewModels.CustomValidations
{
    public class ValidImageFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string[] validExtension = { "JPG", "JPEG", "BMP", "GIF", "PNG" };
                var file = (IFormFile)value;
                var extension = Path.GetExtension(file.FileName).ToUpper().Replace(".", "");

                return validExtension.Contains(extension) && file.ContentType.Contains("image");
            }
            return true;
        }
    }
}
