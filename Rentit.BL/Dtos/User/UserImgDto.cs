using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class UserImgDto
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public string ImgURL { get; set; }
        public UserImgDto(bool isSucess, string message, string url = "")
        {
            IsSucess = isSucess;
            Message = message;
            ImgURL = url;
        }
    }
}
