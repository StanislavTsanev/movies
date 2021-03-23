using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Movies.API.AutoMapper.Converters
{
    public class FormFileToByteArrayConverter : IValueConverter<IFormFile, byte[]>
    {
        public byte[] Convert(IFormFile sourceMember, ResolutionContext context)
        {
            if (sourceMember == null || sourceMember.Length == 0)
            {
                return null;
            }

            byte[] fileByteArray = null;

            using (var fs1 = sourceMember.OpenReadStream())
            using(var ms1 = new MemoryStream())
            {
                fs1.CopyTo(ms1);
                fileByteArray = ms1.ToArray();
            }

            return fileByteArray;
        }
    }
}
